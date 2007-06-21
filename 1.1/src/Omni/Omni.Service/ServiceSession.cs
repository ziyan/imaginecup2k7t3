using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Omni.Service
{
    class ServiceSession : Hashtable
    {
        private Guid id;
        private Data.Connection cn = null;
        private DateTime activeDate = DateTime.Now;
        private UserContext userContext = null;

        public Guid Id
        {
            get { return id; }
        }
        public Data.Connection Connection
        {
            get
            {
                if (cn == null) cn = new Omni.Data.Connection();
                return cn;
            }
        }
        public UserContext UserContext
        {
            get
            {
                if (userContext == null) userContext = new UserContext();
                return userContext;
            }
        }

        private ServiceSession()
            : base()
        {
        }



        private static Dictionary<Guid, ServiceSession> sessions = new Dictionary<Guid, ServiceSession>();
        public static ServiceSession Create()
        {
            while (true)
            {
                Guid id = Guid.NewGuid();
                if (!sessions.ContainsKey(id))
                {
                    ServiceSession session = new ServiceSession();
                    session.id = id;
                    sessions.Add(id, session);
                    return session;
                }
            }
        }
        public static ServiceSession Get(Guid id)
        {
            if (sessions.ContainsKey(id))
            {
                ServiceSession session = (ServiceSession)sessions[id];
                session.activeDate = DateTime.Now;
                return session;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Cannot find session with id = " + id.ToString());
            }
        }
        public static bool Exists(Guid id)
        {
            return sessions.ContainsKey(id);
        }
        public static void Clean()
        {
            List<Guid> subjectToRemove = new List<Guid>();
            foreach (Guid id in sessions.Keys)
            {
                TimeSpan ts = DateTime.Now - ((ServiceSession)sessions[id]).activeDate;
                //TODO: read from config
                if (Math.Abs(ts.TotalMinutes) > 20)
                    subjectToRemove.Add(id);
            }
            for (int i = 0; i < subjectToRemove.Count; i++)
            {
                sessions.Remove(subjectToRemove[i]);
            }
        }
        private static SessionManager manager = new SessionManager();
        class SessionManager
        {
            private Timer timer = new Timer();
            public SessionManager()
            {
                //TODO: read from config
                timer.Interval = 10000;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.AutoReset = true;
            }

            void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                timer.Stop();
                timer.Enabled = false;
                ServiceSession.Clean();
                timer.Enabled = true;
                timer.Start();
            }

        }
    }
}