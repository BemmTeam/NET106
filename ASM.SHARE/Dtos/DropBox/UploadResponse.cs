namespace ASM.SHARE.Dtos.DropBox
{
    public class UploadResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public string Thumb { get; set; }

        public string Path { get; set; }
    }
}
