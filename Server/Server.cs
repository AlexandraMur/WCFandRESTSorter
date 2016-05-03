using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections;
using Owin;
using Microsoft.Owin.Hosting;

namespace sorter
{
    class Server
    {
        static void Main(string[] args)
        {
            Uri receiver_uri = new Uri("http://localhost:8000/Reciever/");
            Uri array_uri = new Uri("http://localhost:8001/Array/");

            string rest_api_service_uri = "http://localhost:12345/";

            ServiceHost receiver_host = new ServiceHost(typeof(Reciever), receiver_uri);
            ServiceHost array_host = new ServiceHost(typeof(Array), array_uri);

            try
            {
                WebApp.Start<Startup>(rest_api_service_uri);
                Console.WriteLine("Web-service is ready");

                receiver_host.AddServiceEndpoint(typeof(IReciever), new WSHttpBinding(), "Reciever");
                WSDualHttpBinding binding = new WSDualHttpBinding();
                binding.SendTimeout = new TimeSpan(0, 0, 5);

                array_host.AddServiceEndpoint(typeof(IArrayStore), binding, "ArrayStore");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;

                receiver_host.Description.Behaviors.Add(smb);
                smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                array_host.Description.Behaviors.Add(smb);

                receiver_host.Open();
                Console.WriteLine("Reciever-service is ready.");
                
                array_host.Open();
                Console.WriteLine("Array callback service is ready.");
                Console.WriteLine("Press <ENTER> to terminate all service.");

                Console.ReadLine();

                receiver_host.Close();
                array_host.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                receiver_host.Abort();
                array_host.Abort();
            }

        }
    }
}
