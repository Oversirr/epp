namespace GameStore.Services.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }

        public int? GameId { get; set; }
        public GameDTO Game { get; set; }
        public int? ParrentCommentId { get; set; }  //comment, which we replied to.
        public CommentDTO ParrentComment { get; set; }
    }
}
