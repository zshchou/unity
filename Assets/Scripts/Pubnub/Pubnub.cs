using System;

namespace PubNubMessaging.Core
{
    public class Pubnub
    {

        #region "PubNub API Channel Methods"

        #region "Subscribe Methods"

        public void Subscribe<T> (string channel, Action<T> userCallback, Action<T> connectCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(connectCallback, CallbackType.Connect);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            pubnub.Subscribe<T> (channel, userCallback, connectCallback, errorCallback);
        }

        public void Subscribe (string channel, Action<object> userCallback, Action<object> connectCallback, Action<PubnubClientError> errorCallback)
        {
            Subscribe<object> (channel, userCallback, connectCallback, errorCallback);
        }
        #endregion

        #region "Publish Methods"
        public bool Publish(string channel, object message, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return Publish<object>(channel, message, true, userCallback, errorCallback);
        }

        public bool Publish<T>(string channel, object message, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return Publish<T>(channel, message, true, userCallback, errorCallback);
        }

        public bool Publish(string channel, object message, bool storeInHistory, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return Publish<object> (channel, message, storeInHistory, userCallback, errorCallback);
        }

        public bool Publish<T>(string channel, object message, bool storeInHistory, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckMessage(message);

            Utility.CheckPublishKey(pubnub.PublishKey);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);

            Utility.CheckJSONPluggableLibrary();

            return pubnub.Publish<T>(channel, message, storeInHistory, userCallback, errorCallback);
        }
        #endregion

        #region "Presence Methods"
        public void Presence<T> (string channel, Action<T> userCallback, Action<T> connectCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(connectCallback, CallbackType.Connect);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            pubnub.Presence<T> (channel, userCallback, connectCallback, errorCallback);
        }

        public void Presence (string channel, Action<object> userCallback, Action<object> connectCallback, Action<PubnubClientError> errorCallback)
        {
            Presence<object> (channel, userCallback, connectCallback, errorCallback);
        }
        #endregion

        #region "DetailedHistory Methods"
        public bool DetailedHistory (string channel, long start, long end, int count, bool reverse, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return DetailedHistory<object> (channel, start, end, count, reverse, false, userCallback, errorCallback);
        }

        public bool DetailedHistory<T> (string channel, long start, long end, int count, bool reverse, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return DetailedHistory<T> (channel, start, end, count, reverse, false, userCallback, errorCallback);
        }

        public bool DetailedHistory (string channel, long start, Action<object> userCallback, Action<PubnubClientError> errorCallback, bool reverse)
        {
            return DetailedHistory<object> (channel, start, -1, -1, reverse, false, userCallback, errorCallback);
        }

        public bool DetailedHistory<T> (string channel, long start, Action<T> userCallback, Action<PubnubClientError> errorCallback, bool reverse)
        {
            return DetailedHistory<T> (channel, start, -1, -1, reverse, false, userCallback, errorCallback);
        }

        public bool DetailedHistory (string channel, int count, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return DetailedHistory<object> (channel, -1, -1, count, false, false, userCallback, errorCallback);
        }

        public bool DetailedHistory<T> (string channel, int count, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return DetailedHistory<T> (channel, -1, -1, count, false, false, userCallback, errorCallback);
        }

        public bool DetailedHistory (string channel, long start, long end, int count, bool reverse, bool includeTimetoken, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return DetailedHistory<object> (channel, start, end, count, reverse, includeTimetoken, userCallback, errorCallback);
        }

        public bool DetailedHistory<T> (string channel, long start, long end, int count, bool reverse, bool includeTimetoken, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            if (string.IsNullOrEmpty (channel) || string.IsNullOrEmpty (channel.Trim ())) {
                throw new ArgumentException ("Missing Channel");
            }
            if (userCallback == null) {
                throw new ArgumentException ("Missing userCallback");
            }
            if (errorCallback == null) {
                throw new ArgumentException ("Missing errorCallback");
            }
            if (JsonPluggableLibrary == null) {
                throw new NullReferenceException ("Missing Json Pluggable Library for Pubnub Instance");
            }

            return pubnub.DetailedHistory<T> (channel, start, end, count, reverse, includeTimetoken, userCallback, errorCallback);
        }

        public bool DetailedHistory (string channel, long start, bool includeTimetoken, Action<object> userCallback, Action<PubnubClientError> errorCallback, bool reverse)
        {
            return DetailedHistory<object> (channel, start, -1, -1, false, includeTimetoken, userCallback, errorCallback);
        }

        public bool DetailedHistory<T> (string channel, long start, bool includeTimetoken, Action<T> userCallback, Action<PubnubClientError> errorCallback, bool reverse)
        {
            return DetailedHistory<T> (channel, start, -1, -1, false, includeTimetoken, userCallback, errorCallback);
        }

        public bool DetailedHistory (string channel, int count, bool includeTimetoken, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return DetailedHistory<object> (channel, -1, -1, count, false, includeTimetoken, userCallback, errorCallback);
        }

        public bool DetailedHistory<T> (string channel, int count, bool includeTimetoken, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return DetailedHistory<T> (channel, -1, -1, count, false, includeTimetoken, userCallback, errorCallback);
        }
        #endregion

        #region "HereNow Methods"
        public bool HereNow (string channel, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return HereNow<object> (channel, true, false, userCallback, errorCallback);
        }

        public bool HereNow (string channel, bool showUUIDList, bool includeUserState, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return HereNow<object> (channel, showUUIDList, includeUserState, userCallback, errorCallback);
        }

        public bool HereNow<T> (string channel, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return HereNow<T> (channel, true, false, userCallback, errorCallback);
        }

        public bool HereNow<T> (string channel, bool showUUIDList, bool includeUserState, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            return pubnub.HereNow<T> (channel, showUUIDList, includeUserState, userCallback, errorCallback);
        }
        #endregion

        #region "GlobalHereNow Methods"
        public bool GlobalHereNow (bool showUUIDList, bool includeUserState, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GlobalHereNow<object> (showUUIDList, includeUserState, userCallback, errorCallback);
        }

        public bool GlobalHereNow<T> (bool showUUIDList, bool includeUserState, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            return pubnub.GlobalHereNow<T> (showUUIDList, includeUserState, userCallback, errorCallback);
        }

        public bool GlobalHereNow (Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GlobalHereNow<object> (true, false, userCallback, errorCallback);
        }

        public bool GlobalHereNow<T> (Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GlobalHereNow<T> (true, false, userCallback, errorCallback);
        }
        #endregion

        #region "WhereNow Methods"
        public void WhereNow (string uuid, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            WhereNow<object> (uuid, userCallback, errorCallback);
        }

        public void WhereNow<T> (string uuid, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            pubnub.WhereNow<T> (uuid, userCallback, errorCallback);
        }
        #endregion

        #region "Unsubscribe Methods"
        public void Unsubscribe<T> (string channel, Action<T> userCallback, Action<T> connectCallback, Action<T> disconnectCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(connectCallback, CallbackType.Connect);
            Utility.CheckCallback(disconnectCallback, CallbackType.Disconnect);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            pubnub.Unsubscribe<T> (channel, userCallback, connectCallback, disconnectCallback, errorCallback);
        }

        public void Unsubscribe (string channel, Action<object> userCallback, Action<object> connectCallback, Action<object> disconnectCallback, Action<PubnubClientError> errorCallback)
        {
            Unsubscribe<object> (channel, userCallback, connectCallback, disconnectCallback, errorCallback);
        }
        #endregion

        #region "PresenceUnsubscribe Methods"
        public void PresenceUnsubscribe (string channel, Action<object> userCallback, Action<object> connectCallback, Action<object> disconnectCallback, Action<PubnubClientError> errorCallback)
        {
            PresenceUnsubscribe<object> (channel, userCallback, connectCallback, disconnectCallback, errorCallback);
        }

        public void PresenceUnsubscribe<T> (string channel, Action<T> userCallback, Action<T> connectCallback, Action<T> disconnectCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(connectCallback, CallbackType.Connect);
            Utility.CheckCallback(disconnectCallback, CallbackType.Disconnect);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            pubnub.PresenceUnsubscribe<T> (channel, userCallback, connectCallback, disconnectCallback, errorCallback);
        }
        #endregion

        #region "Time Methods"
        public bool Time (Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return Time<object> (userCallback, errorCallback);
        }

        public bool Time<T> (Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            return pubnub.Time<T> (userCallback, errorCallback);
        }
        #endregion

        #region "AuditAccess Methods"
        public void AuditAccess<T> (string channel, string authenticationKey, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckSecretKey(pubnub.SecretKey);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);

            pubnub.AuditAccess<T> (channel, authenticationKey, userCallback, errorCallback);
        }

        public void AuditAccess<T> (string channel, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditAccess<T> (channel, "",  userCallback, errorCallback);
        }

        public void AuditAccess<T> (Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditAccess<T> ("", "", userCallback, errorCallback);
        }

        public void AuditAccess (string channel, string authenticationKey, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditAccess<object> (channel, authenticationKey, userCallback, errorCallback);
        }

        public void AuditAccess (string channel, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditAccess<object> (channel, "", userCallback, errorCallback);
        }

        public void AuditAccess (Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditAccess<object> ("", "", userCallback, errorCallback);
        }
        #endregion

        #region "AuditPresenceAccess Methods"
        public void AuditPresenceAccess (string channel, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditPresenceAccess<object> (channel, "",  userCallback, errorCallback);
        }

        public void AuditPresenceAccess (string channel, string authenticationKey, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditPresenceAccess<object> (channel, authenticationKey, userCallback, errorCallback);
        }

        public void AuditPresenceAccess<T> (string channel, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            AuditPresenceAccess<T> (channel, "", userCallback, errorCallback);
        }

        public void AuditPresenceAccess<T> (string channel, string authenticationKey, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckSecretKey(pubnub.SecretKey);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);

            pubnub.AuditPresenceAccess<T> (channel, authenticationKey, userCallback, errorCallback);
        }
        #endregion

        #region "GrantAccess Methods"
        public bool GrantAccess<T> (string channel, bool read, bool write, int ttl, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantAccess<T> (channel, "", read, write, ttl, userCallback, errorCallback);
        }

        public bool GrantAccess<T> (string channel, bool read, bool write, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantAccess<T> (channel, "", read, write, -1, userCallback, errorCallback);
        }

        public bool GrantAccess<T> (string channel, string authenticationKey, bool read, bool write, int ttl, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckSecretKey(pubnub.SecretKey);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);

            return pubnub.GrantAccess<T> (channel, authenticationKey, read, write, ttl, userCallback, errorCallback);
        }

        public bool GrantAccess<T> (string channel, string authenticationKey, bool read, bool write, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantAccess<T> (channel, authenticationKey, read, write, -1, userCallback, errorCallback);
        }

        public bool GrantAccess (string channel, bool read, bool write, int ttl, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantAccess<object> (channel, "", read, write, ttl, userCallback, errorCallback);
        }

        public bool GrantAccess (string channel, bool read, bool write, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantAccess<object> (channel, "", read, write, -1, userCallback, errorCallback);
        }

        public bool GrantAccess (string channel, string authenticationKey, bool read, bool write, int ttl, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantAccess<object> (channel, authenticationKey, read, write, ttl, userCallback, errorCallback);
        }

        public bool GrantAccess (string channel, string authenticationKey, bool read, bool write, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantAccess<object> (channel, authenticationKey, read, write, -1, userCallback, errorCallback);
        }
        #endregion

        #region "GrantPresenceAccess Methods"
        public bool GrantPresenceAccess<T> (string channel, bool read, bool write, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantPresenceAccess<T> (channel, "", read, write, -1, userCallback, errorCallback);
        }

        public bool GrantPresenceAccess<T> (string channel, bool read, bool write, int ttl, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantPresenceAccess<T> (channel, "", read, write, ttl, userCallback, errorCallback);
        }

        public bool GrantPresenceAccess<T> (string channel, string authenticationKey, bool read, bool write, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantPresenceAccess<T> (channel, authenticationKey, read, write, -1, userCallback, errorCallback);
        }

        public bool GrantPresenceAccess<T> (string channel, string authenticationKey, bool read, bool write, int ttl, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckSecretKey(pubnub.SecretKey);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);

            return pubnub.GrantPresenceAccess<T> (channel, authenticationKey, read, write, ttl, userCallback, errorCallback);
        }

        public bool GrantPresenceAccess (string channel, bool read, bool write, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantPresenceAccess<object> (channel, "", read, write, -1, userCallback, errorCallback);
        }

        public bool GrantPresenceAccess (string channel, bool read, bool write, int ttl, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantPresenceAccess<object> (channel, "", read, write, ttl, userCallback, errorCallback);
        }

        public bool GrantPresenceAccess (string channel, string authenticationKey, bool read, bool write, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantPresenceAccess<object> (channel, authenticationKey, read, write, -1, userCallback, errorCallback);
        }

        public bool GrantPresenceAccess (string channel, string authenticationKey, bool read, bool write, int ttl, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            return GrantPresenceAccess<object> (channel, authenticationKey, read, write, ttl, userCallback, errorCallback);
        }
        #endregion

        #region "SetUserState Methods"

        public void SetUserState<T> (string channel, string uuid, string jsonUserState, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            Utility.CheckUserState(jsonUserState);

            pubnub.SetUserState<T> (channel, uuid, jsonUserState, userCallback, errorCallback);
        }

        public void SetUserState<T> (string channel, string jsonUserState, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            SetUserState<T> (channel, "", jsonUserState, userCallback, errorCallback);
        }

        public void SetUserState (string channel, string uuid, string jsonUserState, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            SetUserState<object> (channel, uuid, jsonUserState, userCallback, errorCallback);
        }

        public void SetUserState (string channel, string jsonUserState, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            SetUserState<object> (channel, "", jsonUserState, userCallback, errorCallback);
        }

        public void SetUserState<T> (string channel, string uuid, System.Collections.Generic.KeyValuePair<string, object> keyValuePair, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            pubnub.SetUserState<T> (channel, uuid, keyValuePair, userCallback, errorCallback);
        }

        public void SetUserState<T> (string channel, System.Collections.Generic.KeyValuePair<string, object> keyValuePair, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            SetUserState<T> (channel, "", keyValuePair, userCallback, errorCallback);
        }

        public void SetUserState (string channel, string uuid, System.Collections.Generic.KeyValuePair<string, object> keyValuePair, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            SetUserState<object> (channel, uuid, keyValuePair, userCallback, errorCallback);
        }

        public void SetUserState (string channel, System.Collections.Generic.KeyValuePair<string, object> keyValuePair, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            SetUserState<object> (channel, "", keyValuePair, userCallback, errorCallback);
        }

        #endregion

        #region "GetUserState Methods"
        public void GetUserState<T> (string channel, string uuid, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            Utility.CheckChannel(channel);
            Utility.CheckCallback(userCallback, CallbackType.User);
            Utility.CheckCallback(errorCallback, CallbackType.Error);
            Utility.CheckJSONPluggableLibrary();

            pubnub.GetUserState<T> (channel, uuid, userCallback, errorCallback);
        }

        public void GetUserState<T> (string channel, Action<T> userCallback, Action<PubnubClientError> errorCallback)
        {
            GetUserState<T> (channel, "", userCallback, errorCallback);
        }

        public void GetUserState (string channel, string uuid, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            GetUserState<object> (channel, uuid, userCallback, errorCallback);
        }

        public void GetUserState (string channel, Action<object> userCallback, Action<PubnubClientError> errorCallback)
        {
            GetUserState<object> (channel, "", userCallback, errorCallback);
        }
        #endregion

        #endregion

        #region "PubNub API Other Methods"

        public void TerminateCurrentSubscriberRequest ()
        {
            pubnub.TerminateCurrentSubscriberRequest ();
        }
            
        public void EndPendingRequests ()
        {
            pubnub.EndPendingRequests ();
        }

        public void CleanUp(){
            pubnub.CleanUp ();
        }

        public Guid GenerateGuid ()
        {
            return Utility.GenerateGuid ();
        }

        public void ChangeUUID (string newUUID)
        {
            pubnub.ChangeUUID (newUUID);
        }

        public static long TranslateDateTimeToPubnubUnixNanoSeconds (DateTime dotNetUTCDateTime)
        {
            return Utility.TranslateDateTimeToPubnubUnixNanoSeconds (dotNetUTCDateTime);
        }

        public static DateTime TranslatePubnubUnixNanoSecondsToDateTime (long unixNanoSecondTime)
        {
            return Utility.TranslatePubnubUnixNanoSecondsToDateTime (unixNanoSecondTime);
        }

        #endregion

        #region "Properties"

        public string AuthenticationKey {
            get { return pubnub.AuthenticationKey; }
            set { pubnub.AuthenticationKey = value; }
        }

        public LoggingMethod.Level PubnubLogLevel {
            get { return pubnub.PubnubLogLevel; }
            set { pubnub.PubnubLogLevel = value; }
        }

        public PubnubErrorFilter.Level PubnubErrorLevel {
            get { return pubnub.PubnubErrorLevel; }
            set { pubnub.PubnubErrorLevel = value; }
        }

        public int LocalClientHeartbeatInterval {
            get { return pubnub.LocalClientHeartbeatInterval; }
            set { pubnub.LocalClientHeartbeatInterval = value; }
        }

        public int NetworkCheckRetryInterval {
            get { return pubnub.NetworkCheckRetryInterval; }
            set { pubnub.NetworkCheckRetryInterval = value; }
        }

        public int NetworkCheckMaxRetries {
            get { return pubnub.NetworkCheckMaxRetries; }
            set { pubnub.NetworkCheckMaxRetries = value; }
        }

        public int NonSubscribeTimeout {
            get { return pubnub.NonSubscribeTimeout; }
            set { pubnub.NonSubscribeTimeout = value; }
        }

        public int SubscribeTimeout {
            get { return pubnub.SubscribeTimeout; }
            set { pubnub.SubscribeTimeout = value; }
        }

        public bool EnableResumeOnReconnect {
            get { return pubnub.EnableResumeOnReconnect; }
            set { pubnub.EnableResumeOnReconnect = value; }
        }

        public string SessionUUID {
            get { return pubnub.SessionUUID; }
            set { pubnub.SessionUUID = value; }
        }

        public string Origin {
            get { return pubnub.Origin; }
            set { pubnub.Origin = value; }
        }

        public int PresenceHeartbeat {
            get {
                return pubnub.PresenceHeartbeat;
            }
            set {
                pubnub.PresenceHeartbeat = value;
            }
        }

        public int PresenceHeartbeatInterval {
            get {
                return pubnub.PresenceHeartbeatInterval;
            }
            set {
                pubnub.PresenceHeartbeatInterval = value;
            }
        }

        public IPubnubUnitTest PubnubUnitTest {
            get {
                return pubnub.PubnubUnitTest;
            }
            set {
                pubnub.PubnubUnitTest = value;
            }
        }

        public bool EnableJsonEncodingForPublish {
            get {
                return pubnub.EnableJsonEncodingForPublish;
            }
            set {
                pubnub.EnableJsonEncodingForPublish = value;
            }
        }

        public IJsonPluggableLibrary JsonPluggableLibrary {
            get {
                return PubnubUnity.JsonPluggableLibrary;
            }
            set {
                PubnubUnity.JsonPluggableLibrary = value;
            }
        }

        public string Version{
            get {
                return PubnubUnity.Version;
            }
        }

        #endregion

        #region "Constructors"

        PubnubUnity pubnub;

        public Pubnub (string publishKey, string subscribeKey, string secretKey, string cipherKey, bool sslOn)
        {
            pubnub = new PubnubUnity (publishKey, subscribeKey, secretKey, cipherKey, sslOn);
        }

        public Pubnub (string publishKey, string subscribeKey, string secretKey)
        {
            pubnub = new PubnubUnity (publishKey, subscribeKey, secretKey);
        }

        public Pubnub (string publishKey, string subscribeKey)
        {
            pubnub = new PubnubUnity (publishKey, subscribeKey);
        }

        #endregion

    }
}