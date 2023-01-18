interface Props {
    color: 'white' | 'black';
    piece?: string;
}

const style: React.CSSProperties = {
    width: '50px', 
    height: '50px'
}

const pieceMap: Record<string, string> = {
    'White King': '&#9812;',
    'White Queen': '&#9813;',
    'White Rook': '&#9814;',
    'White Bishop': '&#9815;',
    'White Knight': '&#9816;',
    'White Pawn': '&#9817;',
    'Black King': '&#9818;',
    'Black Queen': '&#9819;',
    'Black Rook': '&#9820;',
    'Black Bishop': '&#9821;',
    'Black Knight': '&#9822;',
    'Black Pawn': '&#9823;'
}

const Square = (props: Props) => {
    const classes: string[] = [
        props.color === 'white' ? 'bg-white' : 'bg-warning',
        'border',
        'border-1',
        'border-dark'
    ];

    const getClassName = (): string => {
        return classes.join(' ');
    }

    const renderPiece = () => {
        if (!props.piece) return;

        const ascii = pieceMap[props.piece];

        return <p className="fs-2 text-center" dangerouslySetInnerHTML={{ __html: ascii }}></p>;
    }

    return (
        <div className={getClassName()} style={style}>
            {renderPiece()}
        </div>
    )
}

export default Square;