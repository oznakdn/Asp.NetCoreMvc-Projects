
var dtable;

$(document).ready(function () { }
    dtable = $('#myTable').DataTable({

        "ajax": { "url": "/Admin/Product/ProductsWithCategory" },
        "columns": [
            { "data": "name" },
            { "data": 'description' },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id", "render": function (data)
                { return `<a href=/Admin/Product/Create</a>`}
                
            }


        ]



    })
);

