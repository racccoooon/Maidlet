using Maidlet;
using Maidlet.demo;

var maidletConfig = new MaidletServerConfiguration("http://0.0.0.0:8088");
var routerBuilder = new MaidletRouterBuilder();
routerBuilder.AddRoot().AddController<DemoController>();
var server = new MaidletServer(maidletConfig, routerBuilder.Build());
server.Run();