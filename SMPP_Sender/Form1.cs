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
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*Tedexis Pasaporte Maestro*/
            /*properties.SystemID = "BSAG";
            properties.Password = "PQzCM6pV";*/

            /*Tedexis Farmatodo*/
            /*properties.SystemID = "FARMATODO";
            properties.Password = "brHlDyUf";*/

            /*Tedexis Perú*/
            /*properties.SystemID = "TDXTESTPER";
            properties.Password = "0zaGxnNw";*/

            /*properties.Port = 17631; //IP port to use
            properties.Host = "200.41.57.109"; //SMSC host name or IP Address
            properties.SystemType = "SMPP";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*MOCEAN SMS*/
            /*properties.SystemID = "icomsmpp";
            properties.Password = "icom246";
            properties.Port = 28001; //IP port to use
            properties.Host = "183.81.161.84"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*Infobip Itech*/
            properties.SystemID = "ItechArgentina";
            properties.Password = "10Itech!";
            properties.Port = 8888; //IP port to use
            properties.Host = "smpp3.infobip.com"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;

            /*Infobip Support*/
            /*properties.SystemID = "soporteitech";
            properties.Password = "1rY23BcPwg!01";
            properties.Port = 8888; //IP port to use
            properties.Host = "smpp3.infobip.com"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*Altera Chile*/
            /*properties.SystemID = "icommtst";
            properties.Password = "F8c0A3c1";
            properties.Port = 55090; //IP port to use
            properties.Host = "165.232.51.235"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*Infobip Iexpandit*/
            /*properties.SystemID = "adelanto2";
            properties.Password = "Ixpandit2018";
            properties.Port = 8888; //IP port to use
            properties.Host = "smpp3.infobip.com"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/


            /*Sistemas Masivos Colombia*/
            /*properties.SystemID = "icommark";
            properties.Password = "AhbfY68";
            properties.Port = 8237; //IP port to use
            properties.Host = "sistemasmasivos.com"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*Identidad SMS Colombia*/
            //properties.SystemID = "icommktPrm";
            //properties.Password = "1C0mmkt$PR";
            /*Identidad Std*/
            //properties.SystemID = "icommktStd";
            //properties.Password = "1C0mmkt$";
            /*Identidad SMS Internacional*/
            /*properties.SystemID = "Icommkt-internacional";
            properties.Password = "Icommkt2019";
            properties.Port = 2875; //IP port to use
            properties.Host = "207.101.124.227"; //SMSC host name or IP Address
            properties.SystemType = "";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*TuLoEnvias Perú*/
            /*properties.SystemID = "iconm_pe";
            properties.Password = "qLOHfEcB";
            properties.Port = 8888; //IP port to use
            properties.Host = "107.20.199.106"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*ITELVOX Perú*/
            /*properties.SystemID = "netv-itechla";
            properties.Password = "1t3chL4";
            properties.Port = 2345; //IP port to use
            properties.Host = "121.241.242.114"; //SMSC host name or IP Address
            properties.SystemType = "sms";
            properties.DefaultServiceType = "SMPP";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*Corzu.Net Chile*/
            /*properties.SystemID = "czn_icommkt";
            properties.Password = "imCzn18";
            properties.Port = 10020; //IP port to use
            properties.Host = "190.107.177.120"; //SMSC host name or IP Address
            properties.SystemType = "";
            properties.DefaultServiceType = "";
            properties.DefaultEncoding = DataCoding.Latin1;*/

            /*CelMedia Chile*/
            /*properties.SystemID = "becedigmt";
            properties.Password = "beceligmt";
            properties.Port = 8507; //IP port to use
            properties.Host = "200.68.3.74"; //SMSC host name or IP Address
            properties.SystemType = "smpp";
            properties.DefaultServiceType = "";
            properties.DefaultEncoding = DataCoding.Latin1;*/
                        
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

                msg.SourceAddress = "1152382000"; //Originating number
                msg.RegisterDeliveryNotification = true; //I want delivery notification for this message
                msg.SubmitUserMessageReference = true;

                client.MessageSent += client_MessageSent;
                client.MessageDelivered += client_MessageDelivered;
                
                //client.SendMessage(msg);
                //client.BeginSendMessage(msg, SendMessageCompleteCallback, client);

                /*Argentina*/
                msg.Text = txtMessage.Text;
                msg.DestinationAddress = txtMobileNumber.Text;
                msg.UserMessageReference = "REF:" + txtMobileNumber.Text + "-" + txtMessage.Text;
                client.SendMessage(msg);

                /*msg.Text = "Leo soy ICOMMKT";
                msg.DestinationAddress = "5491132834954"; //Receipient number
                client.SendMessage(msg);*/

                /*Chile*/
                //msg.SourceAddress = "99994"; //Originating number
                /*msg.Text = "Mensaje de prueba enviado por ICOMMKT, favor confirmar recepcion a nicolas.krasny@itechla.com";
                msg.DestinationAddress = "56958733713"; /*Santiago*/
                //client.SendMessage(msg);*/

                /*Ecuador*/
                /*msg.Text = "Mensaje de prueba enviado por ICOMMKT, favor confirmar recepción a leonardo.faigenbom@itechla.com";
                msg.DestinationAddress = "593993396991";
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
                client.SendMessage(msg); /*ALEX*/
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

                /*msg.Text = "SMS enviado desde Icommarketing, confirmar recepción a Nicolás Krasny (nicolas.krasny@itechla.com)" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                msg.DestinationAddress = "51979411820";
                client.SendMessage(msg);*/

                //MessageBox.Show("Enviado. ID: " + msg.ReceiptedMessageId);
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

        private void client_MessageSent(object sender, MessageEventArgs e)
        {
            var client = (SmppClient)sender;
            Console.WriteLine("SMPP client {0} - Message Sent to: {1} {2}", client.Name, e.ShortMessage.DestinationAddress, e.ShortMessage.UserMessageReference);
            txtResult.Text += "Sent -> ID: " + e.ShortMessage.ReceiptedMessageId + Environment.NewLine;
            // CANDO: save sent sms
        }

        private void client_MessageDelivered(object sender, MessageEventArgs e)
        {
            TextMessage msg = e.ShortMessage as TextMessage;
            //parse msg.Text for more details
            //MessageBox.Show("ID: " + msg.UserMessageReference + ", Text: " + msg.Text, "Message Delivered");
            txtResult.Text += "Delivered -> ID: " + msg.ReceiptedMessageId + " , UserMessageReference: " + msg.UserMessageReference + ", Text: " + msg.Text + Environment.NewLine;

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
