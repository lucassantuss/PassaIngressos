import EventoCard from 'components/EventoCard';
import styles from './EventosDisponiveis.module.css';

const EventosDisponiveis = ( { title, subtitle, urlImage }) => {
  const eventos = [
    {
      title: 'The Weeknd',
      ingressos: 3,
      ano: 2024,
      image: '/images/events/The-Weeknd-2024.jpg',
      reverse: false,
    },
    {
      title: 'Bruno Mars',
      ingressos: 7,
      ano: 2024,
      image: '/images/events/Bruno-Mars-2024.png',
      reverse: true,
    },
  ];

  return (
    <>
      <div className={styles.eventosContainer}>
        <div className={styles.overlay}>
          <h1 className={styles.title}>{title}</h1>
          <p className={styles.subtitle}>{subtitle}</p>
          <div className={styles.searchBox}>
            <input
              type="text"
              placeholder="Digite o nome do evento.."
              className={styles.searchInput}
            />
            <button className={styles.searchButton}>Pesquisar</button>
          </div>
        </div>
      </div>

      <div>
        {eventos.map((evento, index) => (
          <EventoCard key={index} evento={evento} />
        ))}
      </div>
    </>
  );
};

export default EventosDisponiveis;