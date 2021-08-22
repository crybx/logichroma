# How to play multiplayer using IIS Express

Original instructions from [Accessing an IIS Express site from a remote computer](https://johan.driessen.se/posts/Accessing-an-IIS-Express-site-from-a-remote-computer/). Copied here in case of future broken links.

## 1 – Bind your application to your public IP address

Normally when you run an application in IIS Express, it’s only accessible on http://localhost:[someport]. In order to access it from another machine, it needs to be bound to your public IP address as well.

Open `/{project folder}/.vs/config/applicationhost.config.`

In `<bindings>`, add another row:

`<binding protocol="https" bindingInformation="*:44318:192.168.1.42" />`


(But with your IP, and port number, of course)

## 2 - Allow incoming connections

If you’re running Windows 7, pretty much all incoming connections are locked down, so you need to specifically allow incoming connections to your application. First, start an administrative command prompt. Second, run these commands, replacing 192.168.1.42:58938 with whatever IP and port you are using:

`netsh http add urlacl url=http://192.168.1.42:44318/ user=everyone`

This just tells http.sys that it’s ok to talk to this url.

`netsh advfirewall firewall add rule name="IISExpressWeb" dir=in protocol=tcp localport=44318 profile=private remoteip=localsubnet action=allow`

This adds a rule in the Windows Firewall, allowing incoming connections to port 58938 for computers on your local subnet.

And there you go, you can now press Ctrl-F5 in Visual Studio, and browse you site from another computer!
