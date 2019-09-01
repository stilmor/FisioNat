import React, { Component } from 'react';

export class Login extends Component {
  static displayName = Login.name;

  constructor (props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter () {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }
  /*<button className="btn btn-primary" onClick={this.incrementCounter}>Enviar</button>*/
  

  render () {      
    return (
      
      <form method="post" action="/login/usuario" encType="application/json">
      <div>
        <h1>Login</h1>
        User:
        <input type="user" name="user"/>
        <br/><br/>
        
        Password:
        <input type="text" name="password"/>

        <p>Prueba de pantalla de Login.</p>

        <input className="btn btn-primary" type="submit" name="submit" value="Aceptar"/>

      </div>
      </form>
    );
  }
}
