app.service("VehicleCallService",function ($http) {
    var apiUrl = "http://localhost:56682/api/vehicles/";
    var result;
    this.getVehicles = function () {
        return $http.get(apiUrl);
    };

    this.getVehicleById = function (id) {
        return $http.get(apiUrl+"/"+id);
    };


    this.insertNewVehicle = function (data) {
        return $http.post(apiUrl, JSON.stringify(data));
    };

    this.updateVehicleById = function (data) {
        return $http.put(apiUrl+"/"+data.Id,data);
    };

    this.deleteVehicleById = function (id) {
        return $http.delete(apiUrl + "/" + id);
    };

});