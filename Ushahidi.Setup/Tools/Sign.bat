del Ushahidi.snk /Q
del Ushahidi.pVK /Q
del Ushahidi.cer /Q
del Ushahidi.spc /Q
del Ushahidi.pfx /Q
del Ushahidi_sha1.txt /Q
del Ushahidi_base64.txt /Q

sn.exe -k Ushahidi.snk

pause

makecert.exe -r -sv Ushahidi.pvk -n "CN=Ushahidi" -b 01/01/2009 -e 01/01/2099 Ushahidi.cer 

pause

cert2spc.exe Ushahidi.cer Ushahidi.spc

pause

pvk2pfx.exe -pvk Ushahidi.pvk -spc Ushahidi.spc -pfx Ushahidi.pfx -pi goma -po goma

pause

openssl sha1 Ushahidi.cer > Ushahidi_sha1.txt

pause

openssl base64 -in Ushahidi.cer -out Ushahidi_base64.txt

pause