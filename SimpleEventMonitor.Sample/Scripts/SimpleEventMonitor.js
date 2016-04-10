var SEM = {

    setupSignalR: function (dataAdder) {
        var connection = $.hubConnection('/signalr');
        var eventHubProxy = connection.createHubProxy('eventHub');
        eventHubProxy.on('publish', function (data) {
            dataAdder(data);
        });
        connection.start().done(function () {
            eventHubProxy.invoke('subscribe', 'simpleEventMonitorEvents');
        });
    },

    state: {
        pageSize: 10,
        totalCount: 0,
        minIdxShown: 0,
        maxIdxShown: 0,
        items: []
    },

    getInitialData: function (dataAdder, eventGetter, stateData) {
        //First get TotalCount. Then decide what to do next
        $.ajax({
            url: "/TotalCount"
        }).then(function (data) {
            stateData.totalCount = data;
            eventGetter(dataAdder);
        });
    },

    getEvents: function (dataAdder) {
        $.ajax({
            url: "/Events?StartIdx=0&EndIdx=9"
        }).then(function (data) {
            var len = data.length;
            for (var i = 0; i < len; i++) {
                dataAdder(data[i]);
            }
        });


    }
}


//1. Åbning af Side
//	- Hent Total Count 
//Hvis Total Count == 0 - gør ikke mere
//Hvis Total Count <= 20 - Hent - og gør ikke mere
//Hvis Total Count > 20 - Hent 0-19. Ved tryk på Next Hent 20-39 og hvis 20-39

//SignalR signalet lægger noget til som nr. 1 altid.

//ViewModel har værdier for
//Vist Minimum, Vist Maximum, TotalCount

//Prev er enablet hvis Vist Minimum > 20
//Next er enablet hvis Vist Maximum < TotalCount


//2. 
