namespace ChargeIT.Application.Common.Exceptions {

    public class NotFoundException : Exception {
        public NotFoundException()
            : base("Entity not found.") { }

        public NotFoundException(string entity, object key)
            : base(string.Format("Entity ({0}) key not found ({1}).", entity, key)) { }

    }

}