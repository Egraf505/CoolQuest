class CommentBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }
    componentWillMount() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <ul>{ this.state.data}</ul>
            </div>
        );
    }
}

ReactDOM.render(
    <CommentBox url="/comments?roomId=1" pollInterval={2000} />,
    document.getElementById('content'),
);