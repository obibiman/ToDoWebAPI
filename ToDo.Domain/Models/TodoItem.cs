namespace ToDo.Domain.Models
{
    /// <summary>
    /// TodoItem
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// IsComplete
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// Secret
        /// </summary>
        public string Secret { get; set; }
    }
}