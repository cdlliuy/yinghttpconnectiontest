* Run below cmd to repro the issue:

```
docker build -t  yingtestapp:asp80 -f ./Dockerfile.aspnet80 .
docker run -it --rm yingtestapp:asp80
```
You can see the issue reported in https://github.com/dotnet/runtime/issues/98797

* But with below cmd,  the program works good
```
docker build -t  yingtestapp:asp70 -f ./Dockerfile.aspnet70 .
docker run -it --rm yingtestapp:asp70
```
