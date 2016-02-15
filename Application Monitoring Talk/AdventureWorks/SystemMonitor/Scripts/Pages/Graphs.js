var app = angular.module("myApp", ["chart.js"]);
var rowIndex = 0;
var beginDate = new Date();
var endDate = new Date();
var defaultBeginDate = beginDate.getMonth() + 1 + "/" + (beginDate.getDate() + "/" + beginDate.getFullYear());
var defaultEndDate = endDate.getMonth() + 1 + "/" + (endDate.getDate() + "/" + endDate.getFullYear());




app.controller("myCtrl1", function ($filter, $scope, $http, $timeout) {
    //way to set up checkbox for the live graph
   
    $scope.checkboxModel = {
        critical1: { selected: false, id: liveGraphData },
        checkboxModel_Click: function ($event) {

            if ($event.selected == false) {

                return $scope.getData();
            }
            else {
                if ($scope.x) {
                    clearInterval($scope.x);
                    $scope.x = 0; 
                }
           

            }

        }

    }




    $scope.updateTimer = function (time) {
        if ($scope.x) {
            clearInterval($scope.x);
            $scope.x = 0;
        }

        $scope.x = setInterval(function () { $scope.getLiveData(); }, time);
        
        $scope.countDown = $scope.seconds / 1000;

        if ($scope.timer) {
            clearInterval($scope.timer);
            $scope.timer = 0;
        }
        $scope.timer = setInterval(function () {

            if ($scope.countDown > 1) {
                $scope.countDown--;
                countDownTimeOut = $timeout($scope.timer, 1000);
            } else {
                $scope.countDown = $scope.seconds / 1000;

            };

            var countDownTimeOut = $timeout($scope.timer, 1000);
        },
        1000
        );
    }
  



    
    $scope.seconds = [
        { 'timer': '5000' },
        { 'timer': '10000' },
        { 'timer': '30000' },
        { 'timer': '60000' },
    ];

    $scope.seconds_description = [
    { 'lookupCode': '5000', 'description': '5 Seconds' },
    { 'lookupCode': '10000', 'description': '10 Seconds' },
    { 'lookupCode': '30000', 'description': '30 Seconds' },
    { 'lookupCode': '60000', 'description': '60 Seconds' }
    ];



    // function that grabs data from the http method
    $scope.getData = function () {
        beginDate = txtBeginDate.value;
        endDate = txtEndDate.value;
        $scope.v = false;
        if ($scope.x) {
            clearInterval($scope.x);
           
        }
        $scope.checkboxModel.critical1.selected = false; 
        $http.get(apiDataStarted)
               .success(function (response) {
                   $scope.Started = response.Started;
               });

        var durationInMilliseconds = []; 
        
        //gets the data from the MiniProfilerData http request based on the inputed begin and end dates
        $http.get(apiMiniProfilerData + "?beginDate=" + beginDate + "&endDate=" + endDate)
          .success(function (response) {
              $scope.log = response;
              durationInMilliseconds = _.map($scope.log, function (time) {
                  return time.DurationMilliseconds;
              }
          );

             


 




              //request to get the data from the Mini Profiler Timings Table 
              $http.get(apiMiniProfilerTimingsData)
             .success(function (response) {
                 $scope.MiniProfilerTimings = response;
             });

             //request to get data from the Mini Profiler Client Timings table
             /* $http.get(apiMiniProfilerClientTimingsData)
              .success(function (response) {
                  $scope.MiniProfilerClientTimings = response;
              });*/

              //global variable that calculates the standard deviation of the duration in milliseconds 
              $scope.standard = math.abs((math.std(durationInMilliseconds)));

              //global variable that calculates the mean of the duration in milliseconds
              $scope.mean = (math.mean(durationInMilliseconds));

              var counter = 0;

              //amount of x labels on the x axis of the graph
              var length = durationInMilliseconds.length / 25;


              $scope.xLabels = _.map($scope.log, function (time) {
                  if(counter < length){
                      counter++;
                      return "" //$filter('date')(time.Started, 'medium');
                  }
                  else {
                      counter = 0;
                      var date = new Date(time.Started); 
                      return $filter('date')(date.toLocaleString(), 'MM/dd/yyyy @ hh:mm:ss');
                              
                  }
              }
              );

              //drawing of the first standard deviation line 
              var mean = [];
              var std = [];
              for (var i = 0; i < durationInMilliseconds.length; i++) {
                  mean.push($scope.mean);
                  std.push($scope.standard + $scope.mean);
                          
              };


              //drawing of the second standard deviation line
              var mean = [];
              var std = [];
              var std2 = [];

              for (var i = 0; i < durationInMilliseconds.length; i++) {
                  mean.push($scope.mean);
                  std.push($scope.mean + $scope.standard);
                  std2.push($scope.mean + $scope.standard +$scope.standard);
              };
              
              
              var lineGraphOptions = {
                  pointDot: false,
                  responsive: true,
                  mainAspectRatio: false
              }

              //datasets to fill the graph dynamically
              var lineGraphData = {
                  labels: $scope.xLabels,
                  datasets: [{

                      label: "Duration in Milliseconds",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "grey",
                      pointColor: "#666666",
                      data: durationInMilliseconds
                  },
                  {

                      label: "Mean",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "green",
                      pointColor: "#15ba46",
                      data: mean
                  },
                  {
                      label: "Standard Deviation",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "orange",
                      pointColor: "#FFAE19",
                      data: std
                  },
                  {
                      label: "2nd Standard Deviation",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "red",
                      pointColor: "#C62828",
                      data: std2
                  }
                  ]
              }
              //renduring the chart  
              $('#lineGraph').replaceWith('<canvas id="lineGraph"></canvas>');
                      
              var lineGraph = document.getElementById('lineGraph').getContext('2d');
              new Chart(lineGraph).Line(lineGraphData, lineGraphOptions);

              var legend = "<ul style=\"list-style-type: none;\">"
              for (var i = 0; i < lineGraphData["datasets"].length; i++) {
                  legend += "<li class=\"liLegend\"><div class=\"divLegend\" style=\"background-color:" + lineGraphData["datasets"][i]["pointColor"] + ";\"></div>"
                  + lineGraphData["datasets"][i]["label"]+ "</li>"
              }
              legend +="</ul>"
              document.getElementById('chartLegend').innerHTML = legend; 
                        
         
                      


              $scope.labels = $scope.xLabels;
              $scope.series = ['Duration in Milliseconds', 'Standard Deviation', 'Mean', 'Second Standard Deviation'];
              $scope.lineGraphData = [
                  std2, std, mean, durationInMilliseconds
              ];

          });
    }

    //calculates the row index of the table
    $scope.Index = function (rowId) {
        var arrayLength = $scope.log.length;
        for (var i = 0; i < arrayLength; i++){ 
            if ($scope.log[i].RowId == rowId) {
                $scope.rowIndex = i;
                return;
            }
        }

    }

    //converts UTC time to local machine time
    $scope.localTime = function (LocalTime) {
        var date = new Date(LocalTime);
        return date.toLocaleString();
    }


    txtBeginDate.value = defaultBeginDate;
    txtEndDate.value = defaultEndDate;

    //page loads data from today's date range
    $scope.getData(defaultBeginDate, defaultEndDate);//convert back to "default BeginDate"



    $scope.timer = function () {

    }

    //function for the liveGraph chart
    $scope.getLiveData = function () {

        //request to get the date in which the first data entry was made 
        $http.get(apiDataStarted)
               .success(function (response) {
                   $scope.Started = response.Started;
               });

        var durationInMilliseconds = [];

        //request to get the data of the live graph
        $http.get(apiMiniProfilerLiveData)
          .success(function (response) {
              $scope.log = response;
              durationInMilliseconds = _.map($scope.log, function (time) {
                  return time.DurationMilliseconds;
              }
          );

              /*
              //request data from the Mini Profiler Timings Data table
              $http.get(apiMiniProfilerTimingsData)
             .success(function (response) {
                 $scope.MiniProfilerTimings = response;
             });
             */


              //request data from the Mini Profiler Client Timings Data table 
              $http.get(apiMiniProfilerClientTimingsData)
              .success(function (response) {
                  $scope.MiniProfilerClientTimings = response;
              });

              //calculating the standard deviation for the liveGraph
              $scope.standard = math.abs((math.std(durationInMilliseconds)));
              //calculating the mean for the live graph
              $scope.mean = (math.mean(durationInMilliseconds));

              var counter = 0;
              var length = durationInMilliseconds.length / 25;


              //mapping the x labels for the live graph chart 
              $scope.xLabels = _.map($scope.log, function (time) {
                  if (counter < length) {
                      counter++;
                      return "" //$filter('date')(time.Started, 'medium');
                  }
                  else {
                      counter = 0;
                      var date = new Date(time.Started);
                      return $filter('date')(date.toLocaleString(), 'MM/dd/yyyy @ hh:mm:ss');

                  }
              }
              );

              //creating the mean line and the standard deviation line for the live graph
              var mean = [];
              var std = [];
              for (var i = 0; i < durationInMilliseconds.length; i++) {
                  mean.push($scope.mean);
                  std.push($scope.standard + $scope.mean);

              };

              //creating the second standard deviation line for the live graph
              var mean = [];
              var std = [];
              var std2 = [];
             
              for (var i = 0; i < durationInMilliseconds.length; i++) {
                  mean.push($scope.mean);
                  std.push($scope.mean + $scope.standard);
                  std2.push($scope.mean + $scope.standard + $scope.standard);
              };

              var lineGraphOptions = {
                  pointDot:false,
                  responsive: true,
                  mainAspectRatio: false,
                  animation:false
              }

              var lineGraphData = {
                  labels: $scope.xLabels,
                  datasets: [{

                      label: "Duration in Milliseconds",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "grey",
                      pointColor: "#666666",
                      data: durationInMilliseconds
                  },
                  {

                      label: "Mean",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "green",
                      pointColor: "#15ba46",
                      data: mean
                  },
                  {
                      label: "Standard Deviation",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "orange",
                      pointColor: "#FFAE19",
                      data: std
                  },
                  {
                      label: "2nd Standard Deviation",
                      fillColor: "rgba(254, 249, 244, 0.1)",
                      strokeColor: "red",
                      pointColor: "#C62828",
                      data: std2
                  }
                  ]
              }

              //renduring the new canvas for the live graph
              $('#lineGraph').replaceWith('<canvas id="lineGraph"></canvas>');

              var lineGraph = document.getElementById('lineGraph').getContext('2d');
              new Chart(lineGraph).Line(lineGraphData, lineGraphOptions);

              var legend = "<ul style=\"list-style-type: none;\">"
              for (var i = 0; i < lineGraphData["datasets"].length; i++) {
                  legend += "<li class=\"liLegend\"><div class=\"divLegend\" style=\"background-color:" + lineGraphData["datasets"][i]["pointColor"] + ";\"></div>"
                  + lineGraphData["datasets"][i]["label"] + "</li>"
              }
              legend += "</ul>"
              document.getElementById('chartLegend').innerHTML = legend;





              $scope.labels = $scope.xLabels;
              $scope.series = ['Duration in Milliseconds', 'Standard Deviation', 'Mean', 'Second Standard Deviation'];
              $scope.lineGraphData = [
                  std2, std, mean, durationInMilliseconds
              ];

          });
    }

});


