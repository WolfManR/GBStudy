using System.Text.Json.Serialization;

namespace Task5
{
    internal class ToDoTask
    {
        [JsonConstructor]
        public ToDoTask(string title) => Title = title;
        public string Title { get; }
        public bool IsDone { get; set; }

        internal void Done() => IsDone = true;

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => $"[{(IsDone ? "x" : " ")}] {Title}";

        #endregion
    }
}