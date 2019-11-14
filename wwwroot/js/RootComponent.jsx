

function Mistake() {
	return (
		<label class="mistakeLable">
			Looks like you trying to fool me
		</label>
	);
}

function MyFunc() {
	console.log("aaa");
}

class RootComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {value: ''};
	
		this.SomeErrorFunc = this.SomeErrorFunc.bind(this);
		this.handleChange = this.handleChange.bind(this);
	  }

	SomeErrorFunc(){
		console.log("Error catch!");
		event.preventDefault();
	}
	handleChange(){
		console.log("Can i handle you?");
	}

	render() {
		return (
			<div>
				<link href="/css/registration.css" rel="stylesheet" />

				<form className="registrationForm" method="Post" action="/reg" onSubmit={this.SomeErrorFuncs}>
					<label>
						Name:
    			<input type="text" name="name" />
					</label>
					<label>
						Email:
    			<input type="text" name="name" onChange={this.handleChange}/>
					</label>
					<Mistake />
				<input type="submit" value="Submit" />
				</form>
			</div>
		);
	}
}

function SomeElseComponent(p) {
	return (
		<div class="AAAAAAAAAAAAA" > AAAAAAAAAAAAAA</div>
	);
}
