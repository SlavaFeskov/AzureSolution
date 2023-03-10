using System.Data.SqlClient;
using AzureWebApp.Models;
using Microsoft.FeatureManagement;

namespace AzureWebApp.Services;

public class ProductService : IProductService
{
    private readonly IConfiguration _configuration;
    private readonly IFeatureManager _featureManager;

    public ProductService(IConfiguration configuration, IFeatureManager featureManager)
    {
        this._configuration = configuration;
        _featureManager = featureManager;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration["SQLConnection"]);
    }

    public Task<bool> IsBetaAsync()
    {
        return _featureManager.IsEnabledAsync("beta");
    }

    public List<Product> GetProducts()
    {
        List<Product> _product_lst = new List<Product>();
        string _statement = "SELECT ProductID,ProductName,Quantity from Products";
        SqlConnection _connection = GetConnection();

        _connection.Open();

        SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

        using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
        {
            while (_reader.Read())
            {
                Product _product = new Product()
                {
                    ProductID = _reader.GetInt32(0),
                    ProductName = _reader.GetString(1),
                    Quantity = _reader.GetInt32(2)
                };

                _product_lst.Add(_product);
            }
        }

        _connection.Close();
        return _product_lst;
    }
}