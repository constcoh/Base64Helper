# Base64 Helper

The repository contains console app to encode and decode Base64.

### Console Application

Just run Base64Helper.ConsopleApp project and you will see next instructions:
```
Next commands are supported:

 encode, enc - encode row to base64, example:
  \>encode abs qes
  "abs qes" ->
  YWJzIHFlcw==

 decode, dec - decode row from base64, example:
  \>dec YWJzIHFlcw==
  "YWJzIHFlcw==" ->
  abs qes

 encode-file [inputfile] [outputfile] - encode file to base64, examples:
  \>encode-file C:\test\input.zip C:\test\output.zip
  \>encode-file C:\\test\\input.zip C:\\test\\output.zip

 decode-file [inputfile] [outputfile] - decode file from base64, examples:
  \>decode-file C:\test\input.zip C:\test\output.zip
  \>decode-file C:\\test\\input.zip C:\\test\\output.zip
```


### Web Application

Just run Base64Helper.WebApp project and you will see very simple page.
The same functionality is in html.index file.
