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
        items: []
    },

    getInitialData: function (clearView, dataAdder, eventGetter, eventShower, stateData) {
        //First get TotalCount. Then decide what to do next
        $.ajax({
            url: "/TotalCount"
        }).then(function (data) {
            stateData.totalCount = data;
            if (stateData.totalCount > 0) {
                eventGetter(dataAdder, stateData, 0);
            }
        });
    },

    getEvents: function (clearView, dataAdder, eventShower, stateData, from) {
        $.ajax({
            url: "/Events?StartIdx=" + from + "&EndIdx=" + from + stateData.pageSize - 1
        }).then(function (data) {
            var len = data.length;
            for (var i = 0; i < len; i++) {
                stateData.items.push(data[i]);
            }
            eventShower(clearView, dataAdder, stateData);
        });
    },

    showEvents: function (clearView, dataAdder, stateData) {

        clearView();
        var len = stateData.length;
        for (var i = 0; i < len; i++) {
            dataAdder(stateData.items[i]);
        };
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
