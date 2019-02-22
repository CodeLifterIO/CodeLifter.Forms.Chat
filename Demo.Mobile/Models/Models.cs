using System;
using Newtonsoft.Json;

namespace Demo.Models
{
    public partial class QueryResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("sessionId")]
        public Guid SessionId { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("actionIncomplete")]
        public bool ActionIncomplete { get; set; }

        [JsonProperty("contexts")]
        public Context[] Contexts { get; set; }

        [JsonProperty("fulfillment")]
        public Fulfillment Fulfillment { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameters")]
        public ContextParameters Parameters { get; set; }

        [JsonProperty("lifespan")]
        public long Lifespan { get; set; }
    }

    public partial class ContextParameters
    {
    }

    public partial class Fulfillment
    {
        [JsonProperty("messages")]
        public Message[] Messages { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("speech")]
        public string Speech { get; set; }
    }

    public partial class Message
    {
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("textToSpeech", NullValueHandling = NullValueHandling.Ignore)]
        public string TextToSpeech { get; set; }

        [JsonProperty("type")]
        public TypeUnion Type { get; set; }

        [JsonProperty("speech", NullValueHandling = NullValueHandling.Ignore)]
        public string Speech { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("intentId")]
        public Guid IntentId { get; set; }

        [JsonProperty("intentName")]
        public string IntentName { get; set; }

        [JsonProperty("webhookForSlotFillingUsed")]
        public bool WebhookForSlotFillingUsed { get; set; }

        [JsonProperty("webhookUsed")]
        public bool WebhookUsed { get; set; }
    }

    public partial class Parameters
    {
        [JsonProperty("fruit")]
        public string[] Fruit { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; set; }
    }

    public partial struct TypeUnion
    {
        public long? Integer;
        public string String;

        public static implicit operator TypeUnion(long Integer) => new TypeUnion { Integer = Integer };
        public static implicit operator TypeUnion(string String) => new TypeUnion { String = String };
    }
}
