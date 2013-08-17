Hieroglyph
==========

Simple async class library for sending emails through SendGrid


####Use
    //Create recipients
    List<String> recipients = new List<String>();

    recipients.Add("recipient1@email.com");
    recipients.Add("recipient1@email.com");

    //Send email:
    MessagingService messaging = new MessagingService("UserName", "APIKey");
    await messaging.SendEmail(recipients, "{subject}", "{body}", "{from@email.com}", "{fromName}");