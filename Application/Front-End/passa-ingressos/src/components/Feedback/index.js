import "./Feedback.module.css";

function Feedback() {
  return (
    <div className="feedback">
      <h2>Feedback dos Usuários</h2>

      <div className="feedback-list">
        <div className="feedback-item">
          <p>"Muito bom, consegui vender meu ingresso!"</p>
          <span>- Rafael, 27 anos</span>
        </div>

        <div className="feedback-item">
          <p>"Top!! Comprei o ingresso pro show do The Weeknd e deu tudo certo!"</p>
          <span>- Aline, 22 anos</span>
        </div>
        
        <div className="feedback-item">
          <p>"Fácil e seguro, nem precisei conversar com ninguém para vender meu ingresso"</p>
          <span>- Maria, 32 anos</span>
        </div>
      </div>
    </div>
  );
}

export default Feedback;