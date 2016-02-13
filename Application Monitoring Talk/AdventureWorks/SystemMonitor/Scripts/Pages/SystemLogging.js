var app = angular.module("myApp", []);
var rowIndex = 0;
var beginDate = new Date();
var endDate = new Date();
var defaultBeginDate = beginDate.getMonth() + 1 + "/" + (beginDate.getDate() + "/" + beginDate.getFullYear());
var defaultEndDate = endDate.getMonth() + 1 + "/" + (endDate.getDate() + "/" + endDate.getFullYear());

app.controller("myCtrl1", function ($scope, $http) {

    //function that gets data from the System Log Table 
    $scope.getData = function () {
        beginDate = txtBeginDate.value;
        endDate = txtEndDate.value;

        //gets data from the System Logging table 
        $http.get(apiByDates + "?beginDate=" + beginDate + "&endDate=" + endDate)
            .success(function(response)
            {
                $scope.log = response;
            });

        //retrieves the first date for when data was put into the database table 
        $http.get(dataFirstDate)
          .success(function (response)
        {

            $scope.Date = response.Date;
        });

    }
    //calculates where the row ID is so the Modal doesn't get confused 
    $scope.Index = function (rowId) {
        var arrayLength = $scope.log.length;
        for (var i = 0; i < arrayLength; i++)
        {
            if ($scope.log[i].Id == rowId)
            {
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

    $scope.getData(defaultBeginDate, defaultEndDate);

})
    