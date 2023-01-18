interface Props {
    color: 'white' | 'black';
    piece?: string;
}

const style: React.CSSProperties = {
    width: '50px', 
    height: '50px'
}

const pieceMap: Record<string, string> = {
    'white King': '&#9812;',
    'white Queen': '&#9813;',
    'white Rook': '&#9814;',
    'white Bishop': '&#9815;',
    'white Knight': '&#9816;',
    'white Pawn': '&#9817;',
    'black King': '&#9818;',
    'black Queen': '&#9819;',
    'black Rook': '&#9820;',
    'black Bishop': '&#9821;',
    'black Knight': '&#9822;',
    'black Pawn': '&#9823;'
}

const Square = (props: Props) => {
    const classes: string[] = [
        props.color === 'white' ? 'bg-warning' : 'bg-success',
    ];

    const getClassName = (): string => {
        return classes.join(' ');
    }

    const renderPiece = () => {
        if (!props.piece) return;

        const ascii = pieceMap[props.piece];

        return <p className="fs-2" dangerouslySetInnerHTML={{ __html: ascii }}></p>;
    }

    return (
        <div className={getClassName()} style={style}>
            {renderPiece()}
        </div>
    )
}

export default Square;