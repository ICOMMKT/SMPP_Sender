using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JamaaTech.Smpp.Net.Client;
using JamaaTech.Smpp.Net.Lib;

namespace SMPP_Sender
{
    public partial class Form1 : Form
    {
        private static SmppClient client = new SmppClient();

        public Form1()
        {
            InitializeComponent();
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {
            SmppConnectionProperties properties = client.Properties;
            /*BULK SMS*/
            /*properties.SystemID = "546507";
            properties.Password = "ictec885";
            properties.Port = 2775; //IP port to use
            properties.Host = "bulksms.vsms.net"; //SMSC host name or IP Address
            properties.SystemType = "SMPP";
            properties.DefaultServiceType = "SMPP";

            /*Tedexis Pasaporte Maestro*/
            /*properties.SystemID = "BSAG";
            properties.Password = "PQzCM6pV";*/

            /*Tedexis Farmatodo*/
            properties.SystemID = "FARMATODO";
            properties.Password = "brHlDyUf";

            /*Tedexis Perú*/
            /*properties.SystemID = "TDXTESTPER";
            properties.Password = "0zaGxnNw";*/

            properties.Port = 17631; //IP port to use
            properties.Host = "200.41.57.109"; //SMSC host name or IP Address
            properties.SystemType = "SMPP";
            properties.DefaultServiceType = "SMPP";

            /*MOCEAN SMS*/
            /*properties.SystemID = "icomsmpp";
            properties.Password = "icom246";
            properties.Port = 28001; //IP port to use
            properties.Host = "183.81.161.84"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";*/
            

            //Resume a lost connection after 30 seconds
            client.AutoReconnectDelay = 3000;

            //Send Enquire Link PDU every 15 seconds
            client.KeepAliveInterval = 15000;

            client.ConnectionStateChanged += client_ConnectionStateChanged;
            
            //Start smpp client
            client.Start();
            Button.CheckForIllegalCrossThreadCalls = false;
            button1.Enabled = false;

        }

        private void client_ConnectionStateChanged(object sender, ConnectionStateChangedEventArgs e)
        {
            switch (e.CurrentState)
            {
                case SmppConnectionState.Closed:
                    //Connection to the remote server is lost
                    //Do something here
                    e.ReconnectInteval = 60000; //Try to reconnect after 1 min
                    break;
                case SmppConnectionState.Connected:
                    //A successful connection has been established
                    Enable_Button();
                    break;
                case SmppConnectionState.Connecting:
                    //A connection attemp is still on progress
                    break;
            }
        }

        private void client_SmppSessionClosed(object sender, SmppSessionClosedEventArgs e)
        {
            MessageBox.Show(e.Reason.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                TextMessage msg = new TextMessage();

                msg.SourceAddress = "5411452382000"; //Originating number
                msg.RegisterDeliveryNotification = true; //I want delivery notification for this message

                client.MessageDelivered += client_MessageDelivered;

                //client.SendMessage(msg);
                //client.BeginSendMessage(msg, SendMessageCompleteCallback, client);

                /*Argentina*/
                /*msg.Text = "Nico soy ICOMMKT";
                msg.DestinationAddress = "5491132834957"; //Receipient number
                client.SendMessage(msg);

                msg.Text = "Leo soy ICOMMKT";
                msg.DestinationAddress = "5491132834954"; //Receipient number
                client.SendMessage(msg);*/

                /*Chile*/
                msg.Text = "Mensaje de prueba enviado por ICOMMKT, favor confirmar recepción a nicolas.krasny@itechla.com";
                /*msg.DestinationAddress = "5691381660";
                client.SendMessage(msg);*/
                
                /*msg.DestinationAddress = "56977336656";
                client.SendMessage(msg);*/

                /*msg.DestinationAddress = "56981994876";
                client.SendMessage(msg);

                msg.DestinationAddress = "56971821052";
                client.SendMessage(msg);

                msg.DestinationAddress = "56969097929";
                client.SendMessage(msg);*/

                /*Colobia*/
                /*msg.Text = "SMS enviado desde Icommarketing, confirmar recepción a Nico" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                msg.DestinationAddress = "573012897090"; //Receipient number
                client.SendMessage(msg); ALEX*/
                /*msg.Text = "SMS enviado desde Icommarketing, confirmar recepción a Alex" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                msg.DestinationAddress = "573153892047"; //Receipient number
                client.SendMessage(msg);
                msg.Text = "SMS enviado desde Icommarketing, confirmar recepción a Alex" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                msg.DestinationAddress = "573202752495"; //Receipient number
                client.SendMessage(msg);*/

                /*Venezuela*/
                /*msg.Text = "SMS enviado desde Icommarketing, confirmar recepción a Nicolás Krasny (nicolas.krasny@itechla.com)" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                msg.DestinationAddress = "584242740152";
                client.SendMessage(msg);

                msg.Text = "SMS enviado desde Icommarketing, confirmar recepción a Nicolás Krasny (nicolas.krasny@itechla.com)" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                msg.DestinationAddress = "584122575660";
                client.SendMessage(msg);

                msg.Text = "SMS enviado desde Icommarketing, confirmar recepción a Nicolás Krasny (nicolas.krasny@itechla.com)" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                msg.DestinationAddress = "584265121829";
                client.SendMessage(msg);*/

                //msg.DestinationAddress = "584122563615"; //Receipient number
                /*msg.DestinationAddress = "582824252562";
                client.SendMessage(msg);*/

                MessageBox.Show("Enviado");
            }
            catch (Exception ex)
            {
                if (ex is SmppException)
                {
                    SmppException exSmpp = (SmppException)ex;
                    MessageBox.Show(exSmpp.ErrorCode.ToString());
                }
            }
        }

        private void SendMessageCompleteCallback(IAsyncResult result)
        {
            SmppClient client = (SmppClient)result.AsyncState;
            client.EndSendMessage(result);
        }

        private void client_MessageDelivered(object sender, MessageEventArgs e)
        {
            TextMessage msg = e.ShortMessage as TextMessage;
            //parse msg.Text for more details
            MessageBox.Show(msg.Text, "Message Delivered");
        }

        private void Enable_Button()
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Shutdown();
        }
        

    }
}
