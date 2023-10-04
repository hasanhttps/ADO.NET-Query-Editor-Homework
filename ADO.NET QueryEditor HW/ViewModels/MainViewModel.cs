using System;
using System.Data;
using System.Windows;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Collections.Generic;
using ADO.NET_QueryEditor_HW.Commands;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace ADO.NET_QueryEditor_HW.ViewModels;

public class MainViewModel {

    // Private Fields

    string? providerName = null;
    DbConnection? connection = null;
    ComboBox? providerNamesCB = null;
    TabControl? baseTabControl = null;
    DbProviderFactory? providerFactory = null;
    IConfigurationRoot? configuration = null;

    // Properties

    public ICommand? GetAllProvidersCommand { get; set; }
    public ICommand? ExecuteCommand { get; set; }
    public string? ProviderName {
        get => providerName;
        set { 
            providerName = value;
            DatabaseChanged();
        }
    }

    // Constructors

    public MainViewModel(ComboBox providerNamesCB, TabControl baseTabControl) { 

        this.providerNamesCB = providerNamesCB; 
        this.baseTabControl = baseTabControl;

        SetCommands();
        RegisterDbProviderFactory();
        configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }

    // Functions

    public void RegisterDbProviderFactory() {
        DbProviderFactories.RegisterFactory("Sql", typeof(SqlClientFactory));
        DbProviderFactories.RegisterFactory("OleDb", typeof(OleDbFactory));
    }

    public void SetCommands() {
        ExecuteCommand = new RelayCommand(Execute);
        GetAllProvidersCommand = new RelayCommand(GetAllProviders);
    }

    public void DatabaseChanged() {
        var connectionString = configuration.GetConnectionString(providerName);

        providerFactory = DbProviderFactories.GetFactory(providerName!);
        connection = providerFactory.CreateConnection();
        connection!.ConnectionString = connectionString;
    }

    public void GetAllProviders(object? param) {

        providerNamesCB!.Items.Clear();

        DataTable table = DbProviderFactories.GetFactoryClasses();
        foreach (DataRow row in table.Rows) {
            providerNamesCB.Items.Add(row["InvariantName"].ToString());
        }
    }

    public void Execute(object? param) {
        string? query = param as string;

        if (query != null || ! string.IsNullOrEmpty(query) || ! string.IsNullOrWhiteSpace(query)) {
            try {
                DataSet dataSet = new();

                var command = connection!.CreateCommand();
                command.CommandText = query;

                char[] delimiters = { ' ', ';' };
                string[] resultArray = query.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                var adapter = providerFactory!.CreateDataAdapter();

                int count = 0;
                foreach (string data in resultArray) {
                    if (data.ToUpper() != "SELECT" && data.ToUpper() != "FROM" && data != "*") {
                        DataTableMapping myMapping;
                        if (count == 0)
                            myMapping = new DataTableMapping("Table", data);
                        else
                            myMapping = new DataTableMapping("Table" + count.ToString(), data);
                        
                        adapter!.TableMappings.Add(myMapping);

                        count++;
                    }
                }

                adapter!.SelectCommand = command;
                adapter.Fill(dataSet);

                foreach (var item in dataSet.Tables) {
                    DataTable? table = item as DataTable;

                    TabItem tabItem = new TabItem();
                    tabItem.Header = table!.TableName;
                    tabItem.Content = new DataGrid() { ItemsSource = table!.DefaultView};
                    baseTabControl!.Items.Add(tabItem);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}