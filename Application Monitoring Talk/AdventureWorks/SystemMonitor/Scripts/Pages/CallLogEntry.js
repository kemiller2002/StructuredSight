var app = angular.module("myApp", []);
var rowIndex = 0;
var beginDate = new Date();
var endDate = new Date();
var defaultBeginDate = beginDate.getMonth() + 1 + "/" + (beginDate.getDate() + "/" + beginDate.getFullYear());
var defaultEndDate = endDate.getMonth() + 1 + "/" + (endDate.getDate() + "/" + endDate.getFullYear());

app.controller("myCtrl1", function ($scope, $http) {
      
  
    //function that allows angular to retrieve the data from the http requests 
    $scope.getData = function () {
        beginDate = txtBeginDate.value;
        endDate = txtEndDate.value;

        //gets data from the Call Log Entry Dates table 
        $http.get(apiCallLogEntryDates + "?beginDate=" + beginDate + "&endDate=" + endDate)
            .success(function (response) {
                $scope.log = response;
            });

        //gets data from the Call Log Entry Data table 
        $http.get(apiCallLogEntryData)
        .success(function (response) {
            $scope.CallLogEntryType = response;
        });

        //gets data from the Call Log Entry Start Data table 
        $http.get(apiCallLogEntryStartData)
        .success(function (response) {
            $scope.Date = response.Date;
        });

    }

    //calculates the index of the table so when sort is applied modal will know its current place
    $scope.Index = function (callLogEntryId) {
        var arrayLength = $scope.log.length; 
        for (var i = 0; i <arrayLength; i++) {
            if ($scope.log[i].CallLogEntryId == callLogEntryId) {
                $scope.rowIndex = i;
                return;
            }
        }
    }

    //converting UTC time to local machine time
    $scope.localTime = function (LocalTime) {
        var date = new Date(LocalTime);
         return date.toLocaleString();
            }
        
    


    txtBeginDate.value = defaultBeginDate;
    txtEndDate.value = defaultEndDate;


    $scope.getData(defaultBeginDate, defaultBeginDate);


});