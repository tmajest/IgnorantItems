namespace CoffeeCat.TwitchClient.Endpoints.Channels
{
    public abstract class ChannelBaseEndpoint : TwitchEndpoint
    {
        public string ChannelName { get; }

        public abstract string ChannelResource { get; }

        public ChannelBaseEndpoint(string channelName)
        {
            this.ChannelName = channelName;
        }

        public override string Format()
        {
            return $"channels/{this.ChannelName}/{this.ChannelResource}";
        }
    }
}
