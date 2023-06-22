namespace Client.ViewModels
{
    public class ResponseViewModel<TEntity>
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public TEntity Data { get; set; }
    }
}
