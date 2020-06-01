# SampleECommerce with Redis

In this project, it is shown to keep basket transactions in a distributed cache (Redis) in an e-commerce system.

You can run Redis in docker with the following commands.

```
docker pull redis
```

```
docker run -d --name Redis -p 6379:6379 redis
```

If redis is running on a different port on your computer, you can update the port where redis is running in startup.cs file.

```
 services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "SampleECommerce";
                options.Configuration = "localhost:6379"; //Your Redis connection port
            });
```
