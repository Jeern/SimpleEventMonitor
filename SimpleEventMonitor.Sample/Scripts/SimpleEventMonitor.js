function setupSignalR(dataAdder) {
    var connection = $.hubConnection('/signalr');
    var eventHubProxy = connection.createHubProxy('eventHub');
    eventHubProxy.on('publish', function (data) {
        dataAdder(data);
    });
    connection.start().done(function () {
        eventHubProxy.invoke('subscribe', 'simpleEventMonitorEvents');
    });
}
