app.controller('VehicleCallController',function ($scope, VehicleCallService) {
    this.entity = { Year: '', Make: '', Model: '' };
    this.editEntity = {Id:'', Year: '', Make: '', Model: '' };
    var thisApp = this;
    
    this.getAllVehicle = function() {
        var apiCall = VehicleCallService.getVehicles();
        apiCall.then(function (d) {
            $scope.vehicles = d.data;
        }, function (error) {
            $log.error('Error while fetching the data.')
        })
    };
    this.getAllVehicle();

    this.getVehicle = function (id) {
        var apiCall = VehicleCallService.getVehicleById(id);
        apiCall.then(function (d) {
            thisApp.editEntity = d.data;
        }, function (error) {
            $log.error('Error while fetching the data.')
        })
    };


    this.insertNewVehicle = function () {
        VehicleCallService.insertNewVehicle(this.entity)
                .then(function(){
                    thisApp.entity = { Year: '', Make: '', Model: '' };
                    thisApp.getAllVehicle();
                },
                        function (errResponse) {
                            console.error('Error while creating vehicle.');
                        }
            )};

    this.updateVehicle = function () {
        var apiCall = VehicleCallService.updateVehicleById(this.editEntity);
        apiCall.then(function () {
            thisApp.editEntity = { Id: '', Year: '', Make: '', Model: '' };
            thisApp.getAllVehicle();
        }, function (error) {
            $log.error('Error while fetching the data.')
        })
    };

    this.deleteVehicle = function (id) {
        var apiCall = VehicleCallService.deleteVehicleById(id);
        apiCall.then(function(){
            thisApp.editEntity = {Id:'', Year: '', Make: '', Model: '' };
            thisApp.getAllVehicle();
        },
            function (error) {
            $log.error('Error while fetching the data.')
        })
    };
})