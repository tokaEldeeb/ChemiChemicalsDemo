import {
    CallSplit as CallSplitIcon
} from "@material-ui/icons";

const TableOptions = {
    title: "",
    dimensions: {
        datatable: {
            width: "100%",
            height: "600px"
        },
        row: {
            height: "48px"
        }
    },
    keyColumn: "id",
    font: "Arial",
    showPopup : false,
    data: {
        columns: [
            {
                id: "productName",
                label: "Product Name",
                colSize: "100px",
                editable: true,
                dataType: "text",
                inputType: "input",
                valueVerification: val => {
                    let error = val == "" ? true : false;
                    let message = error == true ? "Product Name is required" : "";
                    return {
                        error: error,
                        message: message
                    };
                }
            },
            {
                id: "supplierName",
                label: "Supplier Name",
                colSize: "80px",
                editable: true,
                dataType: "text",
                inputType: "input",
                valueVerification: val => {
                    let error = val == "" ? true : false;
                    let message = error == true ? "Supplier name is required" : "";
                    return {
                        error: error,
                        message: message
                    };
                }
            },
            {
                id: "url",
                label: "Url",
                colSize: "80px",
                editable: true,
                dataType: "text",
                inputType: "input",
                valueVerification: val => {
                    let error = val == "" ? true : false;
                    let message = error == true ? "Url is required" : "";
                    return {
                        error: error,
                        message: message
                    };
                }
            },
            {
                id: "binaryContent",
                label: "Content",
                colSize: "100px",
                editable: false,

            },
            {
                id: "insertionDate",
                label: "Insertion Date",
                colSize: "120px",
                editable: false,
                dateFormatIn: "YYYY-MM-DD",
            }
        ],
        rows: [],
    },
    features: {
        canEdit: true,
        canDelete: true,
        canPrint: false,
        canDownload: false,
        canSearch: true,
        canRefreshRows: false,
        canOrderColumns: true,
        canSelectRow: true,
        canSaveUserConfiguration: false,
        userConfiguration: {
            copyToClipboard: true
        },
        rowsPerPage: {
            available: [10, 25, 50, 100],
            selected: 50
        },
        additionalIcons: [
        ],
        selectionIcons: [
            {
                title: "Selected Rows",
                icon: <CallSplitIcon color="primary" />,
                onClick: rows => console.log(rows)
            }
        ]
    }
};

export default TableOptions;