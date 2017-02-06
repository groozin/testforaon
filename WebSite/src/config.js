let config = {
    customersEndpointUrl: "http://localhost:19780/api/customers"
}

if (process.env.NODE_ENV === 'production') {
     config = {
        customersEndpointUrl: "http://testforaon.azurewebsites.net/api/customers"
    }
}

export { config }
