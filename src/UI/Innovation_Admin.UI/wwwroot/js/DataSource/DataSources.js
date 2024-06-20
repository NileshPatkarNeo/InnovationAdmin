
    $("#dataSourceTable").dataTable({
        pageLength: 5,
    lengthMenu: [[5, 10, 20, -1], [5, 10, 20, 'All']],
    paging: true,
    sorting: true,
    serverSide: false,
    columns: [
    {name: "Sr.No", orderable: true },

    {name: "Name", orderable: true },
    {name: "Action", orderable: false }
    ]
    });

    function confirmDelete(dataId) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Common/DeleteDataSource',
                    type: 'POST',
                    data: { dataId: dataId },
                    success: function (response) {
                        if (response.success) {
                            Swal.fire(
                                'Deleted!',
                                'Your record has been deleted.',
                                'success'
                            ).then(() => {
                                location.reload();
                            });
                        } else {
                            Swal.fire(
                                'Error!',
                                response.message || 'There was an issue deleting the record.',
                                'error'
                            );
                        }
                    },
                    error: function (xhr, status, error) {
                        Swal.fire(
                            'Error!',
                            xhr.responseJSON?.message || 'There was an issue deleting the record.',
                            'error'
                        );
                    }
                });
            }
        });
    }