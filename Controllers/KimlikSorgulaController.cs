using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using BirlesikOdeme.Library.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.IO;

namespace BirlesikOdeme.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KimlikSorgulaController : ControllerBase
    {

        private readonly ILogger<KimlikSorgulaController> _logger;

        public KimlikSorgulaController(ILogger<KimlikSorgulaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "TC Kimlik Sorgula")]
        public HttpResponseMessage GetTCKimlikDogrulama(ulong TCKimlikNo, String Ad, String Soyad, ushort DogumYili)
        {
            TCKimlikDogrulama.TCKimlikNoDogrula tcKimlikDogrulama = new TCKimlikDogrulama.TCKimlikNoDogrula();
            tcKimlikDogrulama.TCKimlikNo = TCKimlikNo;
            tcKimlikDogrulama.Ad = Ad;
            tcKimlikDogrulama.Soyad = Soyad;
            tcKimlikDogrulama.DogumYili = DogumYili;

            TCKimlikDogrulama.EnvelopeBody tcKimlikEnvelopeBody = new TCKimlikDogrulama.EnvelopeBody();
            tcKimlikEnvelopeBody.TCKimlikNoDogrula = tcKimlikDogrulama;

            TCKimlikDogrulama.Envelope tcKimlikEnvelope = new TCKimlikDogrulama.Envelope();
            tcKimlikEnvelope.Body = tcKimlikEnvelopeBody;

            XmlSerializer xsSubmit = new XmlSerializer(typeof(TCKimlikDogrulama.Envelope));
            var subReq = new TCKimlikDogrulama.Envelope();
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, tcKimlikEnvelope);
                    xml = sww.ToString();
                }
            }

            XDocument doc = XDocument.Parse(xml);

            String sDoc = doc.ToString();

            byte[] byteArray = Encoding.UTF8.GetBytes(sDoc);

            CookieContainer cookies = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx");
            //request.CookieContainer = cookies;
            //request.Timeout = 999999;

            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";

            request.ContentLength = byteArray.Length;

            request.Headers.Add("SOAPAction", "http://tckimlik.nvi.gov.tr/WS/TCKimlikNoDogrula");

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                String status = ((HttpWebResponse)response).StatusDescription;

                reader.Close();
                dataStream.Close();
                response.Close();

                if (responseFromServer.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>"))
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, "tamam");
                    return  new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    //return Request.CreateResponse(HttpStatusCode.BadRequest, "Başarısız.");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
