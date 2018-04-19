using System.Collections.Generic;
using ProtoBuf;

namespace Deep.Structure
{


    [ProtoContract]
    internal class FileList
    {
        [ProtoMember(1)]
        public List<FileData> Files { get; set; }

        [ProtoMember(2)]
        public uint Version { get; set; }

    }

    [ProtoContract]
    internal class FileData
    {
        [ProtoMember(1)]
        public string FileName { get; set; }

        [ProtoMember(2)]
        public string Hash { get; set; }

    }


}