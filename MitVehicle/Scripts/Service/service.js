app.service("VehicleCallService", function ($http) {
    var hostPort = "http://localhost:56682";
    var apiUrl = hostPort+"/api/vehicles/";
    var result;

    //Api Call to get all vehicle list
    this.getVehicles = function () {
        return $http.get(apiUrl);
    };

    //Api Call to get vehicle based on ID
    this.getVehicleById = function (id) {
        return $http.get(apiUrl+"/"+id);
    };

    //Api Call to insert new vehicle
    this.insertNewVehicle = function (data) {
        return $http.post(apiUrl, JSON.stringify(data));
    };


    //Api Call to update details of a existing vehicle
    this.updateVehicleById = function (data) {
        return $http.put(apiUrl+"/"+data.Id,data);
    };

    //Api Call to delete a vehicle
    this.deleteVehicleById = function (id) {
        return $http.delete(apiUrl + "/" + id);
    };

});