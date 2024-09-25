import "./ProximosEventos.module.css";

function ProximosEventos() {
  return (
    <div className="events">
      <h2>Próximos eventos</h2>

      <div className="event-list">
        <div className="event">
          <img src="https://github.com/lucassantuss.png" alt="The Weeknd" />
          <p className="event-year">2024</p>
        </div>

        <div className="event">
          <img src="https://github.com/lucassantuss.png" alt="Travis Scott" />
          <p className="event-year">2024</p>
        </div>

        <div className="event">
          <img src="https://github.com/lucassantuss.png" alt="Bruno Mars" />
          <p className="event-year">2024</p>
        </div>
      </div>
    </div>
  );
}

export default ProximosEventos;