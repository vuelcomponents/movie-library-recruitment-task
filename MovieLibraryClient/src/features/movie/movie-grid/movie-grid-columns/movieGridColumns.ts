export const movieGridColumns = [
    {
        headerCheckboxSelection: true,
        checkboxSelection: true,
        showDisabledCheckboxes: true,
        filter: false,
        width: 55,
        editable: false,
        minWidth: 55,
    },
    {
        field: 'id',
        headerName: 'ID',
        width:150,
        headerClass: 'ag-right-aligned-header',
        cellStyle: { textAlign: 'right' },
        cellClass: 'ag-right-aligned-cell',
    },
    {
        field: 'title',
        headerName: 'Title',
        flex:1
    },
    {
        field: 'year',
        headerName: 'Year',
        width:150,
        headerClass: 'ag-right-aligned-header',
        cellStyle: { textAlign: 'right' },
        cellClass: 'ag-right-aligned-cell',
    },
    {
        field: 'director',
        headerName: 'Director',
        width:150,
    },
    {
        field: 'rate',
        headerName: 'Rate',
        width:250,
        cellRenderer:"MovieGridRateRenderer"
    },
]