namespace GameStore.Core.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }

        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
        public int? ParrentCommentId { get; set; }  //comment, which we replied to.
        public virtual Comment ParrentComment { get; set; }
    }
}
