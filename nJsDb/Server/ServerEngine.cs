using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nJsDb.Server
{
    public class ServerEngine
    {
        private List<int> CurrentRequest;

        private Dictionary<string, List<Document>> Collections;

        private Task RequestTask;

        public ServerEngine()
        {

        }

        internal void Load()
        {
            var files = Directory.GetFiles("./Storage");

            foreach (var item in files)
            {
                using (StreamReader reader = new StreamReader(item))
                {
                    var json = reader.ReadToEnd();

                    var items = JsonConvert.DeserializeObject<List<Document>>(json);
                }
            }
         
        }

        public void Request(int identityKey)
        {
            if (CurrentRequest.Add(identityKey))
            {

            }


            if (RequestTask.IsCompleted)
                RequestTask.Start();
        }

        private void DoRequestOnCollection()
        {
            throw new NotImplementedException();
        }
    }
}
