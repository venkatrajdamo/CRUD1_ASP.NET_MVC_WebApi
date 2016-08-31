app.controller('VehicleCallController',function ($scope, VehicleCallService) {
    this.entity = { Year: '', Make: '', Model: '' };
    this.editEntity = {Id:'', Year: '', Make: '', Model: '' };
    var thisApp = this;
    
    //function to get all vehicle list
    this.getAllVehicle = function() {
        var apiCall = VehicleCallService.getVehicles();
        apiCall.then(function (d) {
            $scope.vehicles = d.data;
        }, function (error) {
            console.error('Error: Cannot retrieve vehicle list.')
        })
    };

    this.getAllVehicle();

    //Function to get vehicle based on ID
    this.getVehicle = function (id) {
        var apiCall = VehicleCallService.getVehicleById(id);
        apiCall.then(function (d) {
            thisApp.editEntity = d.data;
        }, function (error) {
            console.error('Error: Cannot retrieve vehicle data.')
        })
    };

    //Function to insert new vehicle
    this.insertNewVehicle = function () {
        VehicleCallService.insertNewVehicle(this.entity)
                .then(function(){
                    thisApp.entity = { Year: '', Make: '', Model: '' };
                    thisApp.getAllVehicle();
                },
                        function (errResponse) {
                            console.error('Error: Cannot craste a new vehicle.');
                        }
            )};

    //Function to update details of a existing vehicle
    this.updateVehicle = function () {
        var apiCall = VehicleCallService.updateVehicleById(this.editEntity);
        apiCall.then(function () {
            thisApp.editEntity = { Id: '', Year: '', Make: '', Model: '' };
            thisApp.getAllVehicle();
        }, function (error) {
            console.error('Error: Cannot update the vehicle.')
        })
    };

    //Function to delete a vehicle
    this.deleteVehicle = function (id) {
        var apiCall = VehicleCallService.deleteVehicleById(id);
        apiCall.then(function(){
            thisApp.editEntity = {Id:'', Year: '', Make: '', Model: '' };
            thisApp.getAllVehicle();
        },
            function (error) {
                console.error('Error: Cannot delete the vehicle.')
        })
    };
})