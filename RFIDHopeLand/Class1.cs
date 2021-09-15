using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDReaderAPI.Models;

namespace RFIDHopeLand
{
    public class AsynchronousMessage: RFIDReaderAPI.Interface.IAsynchronousMessage
    {
        public void WriteDebugMsg(string msg)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string msg)
        {
            throw new NotImplementedException();
        }

        public void PortConnecting(string connID)
        {
            throw new NotImplementedException();
        }

        public void PortClosing(string connID)
        {
            throw new NotImplementedException();
        }

        public void OutPutTags(Tag_Model tag)
        {
            throw new NotImplementedException();
        }

        public void OutPutTagsOver()
        {
            throw new NotImplementedException();
        }

        public void GPIControlMsg(GPI_Model gpi_model)
        {
            throw new NotImplementedException();
        }
    }
}
