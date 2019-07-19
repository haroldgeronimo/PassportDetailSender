using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlusTekPassportDetailSender
{
    class PassportDetailProcessor
    {
        bool IsRunning = false;

        public SystemStatus status = SystemStatus.IDLE;
        
        int refreshSpeed = 1000;

        PassportDetailReader pdr;

        int currentCount = 0;

        Thread mainThread;

        public string message = String.Empty;

        public delegate void UIMessageEventsHandler(object sender, UIMessageEventArgs args);
        public delegate void UIStatusEventsHandler(object sender, UIStatusEventArgs args);

        public event UIMessageEventsHandler UIMessage;
        public event UIStatusEventsHandler UIStatus;

        protected virtual void OnNewMessage(string message)
        {
            if (UIMessage != null)
            {
                UIMessage(this, new UIMessageEventArgs(message));
            }
        }

        protected virtual void OnNewStatus(string status)
        {
            if (UIStatus != null)
            {
                UIStatus(this, new UIStatusEventArgs(status));
            }
        }
        void PassportCheck()
        {
            UIMessage(this, new UIMessageEventArgs("Starting..."));
            currentCount = pdr.GetCount();
            IsRunning = true;
            Thread.Sleep(1000);

            UIMessage(this, new UIMessageEventArgs("Started"));
            UIMessage(this, new UIMessageEventArgs("Waiting for new scan."));
            while (IsRunning)
            {
                status = SystemStatus.RUNNING;
                UIStatus(this, new UIStatusEventArgs(status.ToString()));

                if (!IsRunning) break;
                Thread.Sleep(refreshSpeed);
                if (currentCount <= 0) continue;

                if (currentCount != pdr.GetCount())
                {

                    currentCount = pdr.GetCount();
                    Passport p = pdr.GetLast();
                    try
                    {
                        SendPassport(p);
                        //UIMessage(this, new UIMessageEventArgs("Sent!"));
                    }
                    catch (Exception)
                    {
                        
                        Stop();
                    }

                    

                }
                


            }
            mainThread.Abort();

        }

        public void Start()
        {
            status = SystemStatus.STARTING;
            UIStatus(this, new UIStatusEventArgs(status.ToString()));
            try
            {


                pdr = new PassportDetailReader();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                status = SystemStatus.IDLE;
                UIStatus(this, new UIStatusEventArgs(status.ToString()));
                return;
            }
            
            mainThread = new Thread(PassportCheck);
            mainThread.Start();
        }
        public void Stop()
        {

            UIMessage(this, new UIMessageEventArgs("Stopped!"));
            if (mainThread != null)
                mainThread.Abort();
            status = SystemStatus.IDLE;
            UIStatus(this, new UIStatusEventArgs(status.ToString()));
            IsRunning = false;
        }
        public void SendPassport(Passport p)
        {
            UIMessage(this, new UIMessageEventArgs("Sending Passport:" + p.documentNumber));
            try
            { 
                string passportJson = p.ToJSON();
               // UIMessage(this, new UIMessageEventArgs(passportJson));
                WebHandler.SendDataByJSON(passportJson);
            UIMessage(this, new UIMessageEventArgs("Sent"));
                UIMessage(this, new UIMessageEventArgs("Waiting for new scan."));
                
            }
            catch (Exception e)
            {
                UIMessage(this, new UIMessageEventArgs("Send Failed:" + e.Message));

            }
        }

        public void Test()
        {
            SendPassport(new Passport("TESTDATA"));
        }

        public void SendLast()
        {
            SendPassport(pdr.GetLast());
        }
    }
}
