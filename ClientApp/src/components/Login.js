import React, { Component } from 'react';

export class Login extends Component {
  static displayName = Login.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };

  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }
  /*<button className="btn btn-primary" onClick={this.incrementCounter}>Enviar</button>*/


  render() {
    return (

      <div>
        <form method="post" action="/login/usuario" encType="application/json" Content-Encoding = "application/json">

        <p>Prueba de pantalla de Login.</p>
        <h1>Login</h1>
        User:
        <input type="user" name="user" />
        <br /><br />

        Password:
        <input type="text" name="password" />
        <br /><br />

        <input className="btn btn-primary" type="submit" name="submit" value="Aceptar" />

        </form>

      </div >

    );
  }
}
