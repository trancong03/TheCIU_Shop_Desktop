public partial class BaseCrudForm<T> : Form where T : class, new()
{
    protected readonly BLLBase<T> bll;

    public BaseCrudForm(BLLBase<T> bll)
    {
        this.bll = bll;
        InitializeComponent();
    }

    protected virtual void LoadData()
    {
        var data = bll.GetAll();
        dataGridView.DataSource = data;
    }

    protected virtual void AddItem(T item)
    {
        if (bll.Add(item))
        {
            MessageBox.Show("Item added successfully.");
            LoadData();
        }
        else
        {
            MessageBox.Show("Failed to add item.");
        }
    }

    protected virtual void UpdateItem(T item)
    {
        if (bll.Update(item))
        {
            MessageBox.Show("Item updated successfully.");
            LoadData();
        }
        else
        {
            MessageBox.Show("Failed to update item.");
        }
    }

    protected virtual void DeleteItem(int id)
    {
        if (bll.Delete(id))
        {
            MessageBox.Show("Item deleted successfully.");
            LoadData();
        }
        else
        {
            MessageBox.Show("Failed to delete item.");
        }
    }
}
