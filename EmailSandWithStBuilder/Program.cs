
using EmailSandWithStBuilder;
using System.Text;

StudentemailsysContext studentemailsysContext = new StudentemailsysContext();

var data = studentemailsysContext.StudentMaildetails.ToList();

var tamp =studentemailsysContext.EmailTamps.Where(y=>y.EmailTampName== "Registration").FirstOrDefault();

foreach (var x in data)
{
    var sub = new StringBuilder(tamp.EmailTampTitle);
    sub.Replace("##Name##", x.Name);

    var body = new StringBuilder(tamp.EmailTampBody);
    body.Replace("##Name##", x.Name);
    body.Replace("##Email##", x.Email);
    body.Replace("##PhoneNumber##", Convert.ToString(x.PhoneNumber));

    Helper.SendNotification(x.Email, sub.ToString(), body.ToString());

}