var app = angular.module("myApp", []);
var rowIndex = 0;
var beginDate = new Date();
var endDate = new Date();
var defaultBeginDate = beginDate.getMonth() + 1 + "/" + (beginDate.getDate() + "/" + beginDate.getFullYear());
var defaultEndDate = endDate.getMonth() + 1 + "/" + (endDate.getDate() + "/" + endDate.getFullYear());
                

                

app.controller("myCtrl1", function  ($scope, $http) {


    //function that gets and sorts data from the Mini Profiler table
    $scope.getData = function () {
        beginDate = txtBeginDate.value;
        endDate = txtEndDate.value;

        //data request from the Mini Profiler table 
        $http.get(apiByDates + "?beginDate=" + beginDate + "&endDate=" + endDate)
          .success(function (response) {
              $scope.log = response;
              $scope.times = _.map($scope.log, function (time)
              {
                  return time.DurationMilliseconds;
              }
          );
              //calculating the standard deviation and mean of the times so they can be color coated in the table 
              $scope.standard = (math.std($scope.times));
              $scope.mean = (math.mean($scope.times)); 
          });

        /*
        //data request from the Mini Profiler Timings table 
        $http.get(apiMiniProfilerTimings)
         .success(function (response) {
             $scope.MiniProfilerTimings = response;
         });

        //data request from the Mini Profiler Client Timings table 
        $http.get(apiMiniProfilerClientTimings)
        .success(function (response) {
            $scope.MiniProfilerClientTimings = response;
        });*/

        //data request from Mini Profiler Start Date table
        $http.get(apiMiniProfilerStartDate)
         .success(function (response) {
             $scope.Started = response.Started;
         });

    }

    //calculating index so modal knows current place 
    $scope.Index = function (rowId) {
        var arrayLength = $scope.log.length;

        $scope.MiniProfilerTimings = [];

        for (var i = 0; i < arrayLength; i++) {

            if ($scope.log[i].RowId === rowId) {
                var logItem = $scope.log[i];

                $http.get(apiMiniProfilerTimings + "?miniProfilerId=" + logItem.Id).success(function (response) {
                    $scope.MiniProfilerTimings = response;
                });
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