require 'gosu'

class ChessboardWindow < Gosu::Window
  WIDTH = 470
  HEIGHT = 470
  SQUARE_SIZE = WIDTH / 7.99
  
  class Piece
    attr_accessor :type, :color
    
    def initialize(type, color)
      @type = type
      @color = color
    end
  end
  
  def initialize
    super(WIDTH, HEIGHT)
    load_images
    @chessboard = Array.new(16) { Array.new(16) }
    initialize_pieces
    @selected_piece = nil
    @selected_piece_x = nil
    @selected_piece_y = nil
    @next_player_turn = :black

    
  end
  
  def load_images
    @white_pawn = Gosu::Image.new("white_pawn.png") # https://commons.wikimedia.org/wiki/Category:PNG_chess_pieces/Standard_transparent
    @white_rook = Gosu::Image.new("white_rook.png")
    @white_bishop = Gosu::Image.new("white_bishop.png")
    @white_knight = Gosu::Image.new("white_knight.png")
    @white_king = Gosu::Image.new("white_king.png")
    @white_queen = Gosu::Image.new("white_queen.png")
    
    @black_pawn = Gosu::Image.new("black_pawn.png")
    @black_rook = Gosu::Image.new("black_rook.png")
    @black_bishop = Gosu::Image.new("black_bishop.png")
    @black_knight = Gosu::Image.new("black_knight.png")
    @black_king = Gosu::Image.new("black_king.png")
    @black_queen = Gosu::Image.new("black_queen.png")

  end
  
  def initialize_pieces
    @chessboard[0][0] = Piece.new(@black_rook, :black)
    @chessboard[0][1] = Piece.new(@black_knight, :black)
    @chessboard[0][2] = Piece.new(@black_bishop, :black)
    @chessboard[0][3] = Piece.new(@black_queen, :black)
    @chessboard[0][4] = Piece.new(@black_king, :black)
    @chessboard[0][5] = Piece.new(@black_bishop, :black)
    @chessboard[0][6] = Piece.new(@black_knight, :black)
    @chessboard[0][7] = Piece.new(@black_rook, :black)
    
    @chessboard[7][0] = Piece.new(@white_rook, :white)
    @chessboard[7][1] = Piece.new(@white_knight, :white)
    @chessboard[7][2] = Piece.new(@white_bishop, :white)
    @chessboard[7][3] = Piece.new(@white_queen, :white)
    @chessboard[7][4] = Piece.new(@white_king, :white)
    @chessboard[7][5] = Piece.new(@white_bishop, :white)
    @chessboard[7][6] = Piece.new(@white_knight, :white)
    @chessboard[7][7] = Piece.new(@white_rook, :white)
    
    (0..7).each do |i|
      @chessboard[1][i] = Piece.new(@black_pawn, :black)
      @chessboard[6][i] = Piece.new(@white_pawn, :white)
    end
  end
  
  def draw
    draw_chessboard
    draw_pieces
    highlight_valid_moves
  end
  
  def draw_chessboard
    alternating_colors = [Gosu::Color::WHITE, Gosu::Color::GRAY]
    alternating_colors_cycle = alternating_colors.cycle
    
    (0..7).each do |i_row|
      (0..7).each do |i_column|
        color = alternating_colors_cycle.next
        Gosu.draw_rect(i_row * SQUARE_SIZE, i_column * SQUARE_SIZE , SQUARE_SIZE , SQUARE_SIZE , color)
      end
      alternating_colors_cycle.next # Skip to the next color for the next row
    end
  end
  
  def draw_pieces
    (0..7).each do |i_row|
      (0..7).each do |i_column|
        piece = @chessboard[i_column][i_row]
        next if piece.nil?
        
        piece_image = piece.type
        piece_image.draw(i_row * SQUARE_SIZE, i_column * SQUARE_SIZE, 0)
      end
    end
  end
  
  def button_down(id)
    if id == Gosu::MsLeft
      mouse_x_square = (mouse_x / SQUARE_SIZE).to_i
      mouse_y_square = (mouse_y / SQUARE_SIZE).to_i
      
      if @selected_piece.nil? 
        # If no piece is selected, check if the clicked square contains a piece
        if @chessboard[mouse_y_square][mouse_x_square]
          @selected_piece = @chessboard[mouse_y_square][mouse_x_square]
          @selected_piece_x = mouse_x_square
          @selected_piece_y = mouse_y_square
        end
      else
        # If a piece is selected, move it to the clicked square
        if valid_move?(@selected_piece_x, @selected_piece_y, mouse_x_square, mouse_y_square)
          @chessboard[mouse_y_square][mouse_x_square] = @selected_piece
          @chessboard[@selected_piece_y][@selected_piece_x] = nil
          switch_turns
        end
        
        # Reset selection
        @selected_piece = nil
        @selected_piece_x = nil
        @selected_piece_y = nil
        
      end
    end
  end

  def highlight_valid_moves
    return unless @selected_piece
  
    (0..7).each do |i_row|
      (0..7).each do |i_column|
        if valid_move?(@selected_piece_x, @selected_piece_y, i_column, i_row)
          highlight_color = Gosu::Color.argb(0x40_00ff00)
          Gosu.draw_rect(i_column  * SQUARE_SIZE, i_row * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE, highlight_color)
        end
      end
    end
  end

  def switch_turns
    @next_player_turn = (@next_player_turn == :white) ? :black : :white
    puts "Next player turn: #{@next_player_turn}"
  end
  
  def valid_move?(start_x, start_y, end_x, end_y)
    # Add logic to check if the move is valid
    # For example, check the piece type and color and implement specific movement rules
    # Return true if the move is valid, false otherwise
    piece = @chessboard[start_y][start_x]
    dx = (end_x - start_x).abs
    dy = (end_y - start_y).abs
    da = end_x - start_x
    db = end_y - start_y
    
    if @chessboard[start_y][start_x]&.color == @next_player_turn
      return false
    end
    
    if @chessboard[end_y][end_x]&.color == piece.color # Check if the destination square is not occupied by a piece of the same color
      return false
    end
    
    case piece.type

    when @white_knight, @black_knight
      return (dx == 2 && dy == 1) || (dx == 1 && dy == 2) # Check if the move is a valid knight move (L-shape)

    when @white_pawn
      if da == 0 && (db == -1 || (db == -2 && start_y == 6))  # Check if the move is a valid pawn move
        return @chessboard[end_y][end_x].nil? # Check if the destination square is unoccupied

      elsif dx == 1 && db == -1  # Check if the diagonal destination square has an enemy piece
        return @chessboard[end_y][end_x] != nil && @chessboard[end_y][end_x].color == :black
      end

    when @black_pawn
      if dx == 0 && (dy == 1 || (dy == 2 && start_y == 1))  # Check if the move is a valid pawn move
        return @chessboard[end_y][end_x].nil? # Check if the destination square is unoccupied
      elsif dx == 1 && dy == 1
        return @chessboard[end_y][end_x] != nil && @chessboard[end_y][end_x].color == :white # Check if the destination square has an enemy piece
      else
        return false
      end

    when @white_bishop, @black_bishop
      if (dx == dy) && (dx > 0 && dy > 0)  # Check if the move is a valid bishop move
        check_direction_x = (end_x - start_x) / dx  # 1 (downward) or -1 (upward)
        check_direction_y = (end_y - start_y) / dy  # 1 (right) or -1 (left)
        
        (1...dx).each do |i|
          x = start_x + i * check_direction_x
          y = start_y + i * check_direction_y
          
          return false unless @chessboard[y][x] == nil
        end
      end
      
    when @white_rook, @black_rook
      if (dx == 0 && dy != 0) || (dx != 0 && dy == 0)
        if dx == 0
          check_direction_x = 0
          check_direction_y = (end_y - start_y) / dy # 1 (downward) or -1 (upward)
        elsif dy == 0
          check_direction_x = (end_x - start_x) / dx # 1 (right) or -1 (left)
          check_direction_y = 0
        end
        
        (1...[dx, dy].max).each do |i|
          x = start_x + i * check_direction_x
          y = start_y + i * check_direction_y
          
          return false unless @chessboard[y][x] == nil       
        end
      end
      
    when @white_king
      #if dx == 2 && dy == 0 
        #castling_dx = (end_x - start_x)
        #castling_dy = 7

        #if castling_dx < 0
          #@rook_x = 0
          #(-1...1).each do |i|
           # x = end_x + i * -1
            #y = 7
            #return false unless @chessboard[y][x] == nil
            #@chessboard[7][rook_x] = nil
           # @chessboard[7][end_x + 1] = Piece.new(@white_rook, :white)
         # end

       # elsif castling_dx > 0
          #@rook_x = 7
          #(-1...0).each do |i|
           # x = end_x + i * 1
           # y = 7
            #return false unless @chessboard[y][x] == nil
            #@chessboard[7][@rook_x] = nil
           # @chessboard[7][end_x - 1] = Piece.new(@white_rook, :white)         
        #  end
        #end

        #return true 
      
      if (dx == 0 && dy == 1) || (dx == 1 && dy == 0) || (dx == dy && dy == 1) #king's move

        knight_positions = [   # check for attacking knight in destination square
          [end_y + 1, end_x + 2], [end_y + 1, end_x - 2],
          [end_y - 1, end_x + 2], [end_y - 1, end_x - 2],
          [end_y + 2, end_x - 1], [end_y + 2, end_x + 1],
          [end_y - 2, end_x - 1], [end_y - 2, end_x + 1]
        ]
        pawn_positions = []
        (-1..1).each do |offset|
          pawn_positions << [end_y + offset, end_x + offset]
        end

        queen_positions = []  # check for attacking queen in destination square
        (-7..7).each do |offset|
          queen_positions << [end_y + offset, end_x] 
          queen_positions << [end_y, end_x + offset] 
          queen_positions << [end_y + offset, end_x + offset] 
          queen_positions << [end_y + offset, end_x - offset] 
        end

        rook_positions = []  # check for attacking rook in destination square
        (-7..7).each do |offset|
          rook_positions << [end_y + offset, end_x] 
          rook_positions << [end_y, end_x + offset] 
        end

        bishop_positions = [] # check for attacking bishop in destination square
        (-7..7).each do |offset|
          bishop_positions << [end_y + offset, end_x + offset] 
          bishop_positions << [end_y + offset, end_x - offset] 
        end

        king_positions = []  # check for attacking king in destination square
        (-1..1).each do |offset|
          king_positions << [end_y + offset, end_x] 
          king_positions << [end_y, end_x + offset] 
          king_positions << [end_y + offset, end_x + offset] 
          king_positions << [end_y + offset, end_x - offset] 
        end
        
        black_king_threat = king_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @black_king }
        black_knight_threat = knight_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @black_knight }     

#####################################- CHECK FOR BLACK BISHOP'S ATTACK IN DESTINATION SQUARE -######################################
        check_bishop_direction_x = 0
        check_bishop_direction_y = 0  
        
        bishop_threat = []  

        (0...8).each do |m|
          (0...8).each do |n|
            if @chessboard[n][m]&.type == @black_bishop
            bishop_dx = (m - end_x).abs
            bishop_dy = (n - end_y).abs
  
              if  bishop_dx == bishop_dy 
                check_bishop_direction_x = (m - end_x) /  bishop_dx
                check_bishop_direction_y = (n - end_y) / bishop_dy
              end
        
              bishop_threat = []
              b = 1
              loop do
              @x_bishop = end_x + (b * check_bishop_direction_x)
              @y_bishop = end_y + (b * check_bishop_direction_y)
                break if b == [bishop_dx, bishop_dy].max
              bishop_threat << [@y_bishop, @x_bishop]  
              b += 1
              end
            end
          end
        end
    
        if (bishop_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil}) || (bishop_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil || @chessboard[pos[0]][pos[1]]&.type == @white_king})
        black_bishop_threat = bishop_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @black_bishop }
        else 
        black_bishop_threat = true 
        end

############################################################- CHECK FOR BLACK QUEEN'S ATTACK IN DESTINATION SQUARE -##############################################################
        check_queen_direction_x = 0
        check_queen_direction_y = 0  
        queen_threat = []     

        (0...8).each do |i|
          (0...8).each do |j|
            if @chessboard[j][i]&.type == @black_queen
            queen_dx = (i - end_x).abs
            queen_dy = (j - end_y).abs
            puts "i and j #{j}; #{i}"
            puts "end_x and end_y #{end_y}; #{end_x}"
        
              if queen_dx == 0
                check_queen_direction_x = 0
                check_queen_direction_y = (j - end_y) / queen_dy
              elsif  queen_dy == 0
                check_queen_direction_x = (i - end_x) /  queen_dx
                check_queen_direction_y = 0
              elsif  queen_dx == queen_dy 
                check_queen_direction_x = (i - end_x) / queen_dx
                check_queen_direction_y = (j - end_y) / queen_dy
              end
        
              queen_threat = []
              q = 1
              loop do
              @x_queen = end_x + (q * check_queen_direction_x)
              @y_queen = end_y + (q * check_queen_direction_y)
                break if q == [queen_dx, queen_dy].max
              queen_threat << [@y_queen, @x_queen]  
              q += 1
              puts "Queen Threat Path: #{queen_threat.inspect}" #queen threat debug
              end
            end
          end
        end
    
        if (queen_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil}) || (queen_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil || @chessboard[pos[0]][pos[1]]&.type == @white_king})
        black_queen_threat = queen_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @black_queen }
        else 
        black_queen_threat = true 
        end
###################################################- CHECK FOR BLACK ROOK'S ATTACK IN DESTINATION SQUARE -###########################################################################
        check_rook_direction_x = 0
        check_rook_direction_y = 0  
        rook_threat = []     

        (0...8).each do |i|
          (0...8).each do |j|
            if @chessboard[j][i]&.type == @black_rook
            rook_dx = (i - end_x).abs
            rook_dy = (j - end_y).abs
            puts "i and j #{j}; #{i}"
            puts "end_x and end_y #{end_y}; #{end_x}"
        
              if rook_dx == 0
                check_rook_direction_x = 0
                check_rook_direction_y = (j - end_y) / rook_dy
              elsif  rook_dy == 0
                check_rook_direction_x = (i - end_x) /  rook_dx
                check_rook_direction_y = 0
              elsif  rook_dx == rook_dy 
                check_rook_direction_x = (i - end_x) / rook_dx
                check_rook_direction_y = (j - end_y) / rook_dy
              end
        
              rook_threat = []
              q = 1
              loop do
              @x_rook = end_x + (q * check_rook_direction_x)
              @y_rook = end_y + (q * check_rook_direction_y)
                break if q == [rook_dx, rook_dy].max
              rook_threat << [@y_rook, @x_rook]  
              q += 1
              puts "Queen Threat Path: #{rook_threat.inspect}" #queen threat debug
              end
            end
          end
        end
    
        if (rook_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil}) || (rook_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil || @chessboard[pos[0]][pos[1]]&.type == @white_king})
        black_rook_threat = rook_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @black_rook }
        else 
        black_rook_threat = true 
        end

######################################################################################################################################################################################################
          
        return ( black_knight_threat && black_queen_threat && black_rook_threat && black_bishop_threat && black_king_threat )  
        
      end
        
    when @black_king
      #if dx == 2 && dy == 0 
        #castling_dx = (end_x - start_x)
        #castling_dy = 7
      
        #if castling_dx < 0
          #rook_x = 0
          #(-1...1).each do |i|
           # x = end_x + i * -1
           # y = 0
           # return false unless @chessboard[y][x] == nil
           # @chessboard[0][rook_x] = nil
           # @chessboard[0][end_x + 1] = Piece.new(@black_rook, :black)
         # end
      
       # elsif castling_dx > 0
        #  rook_x = 7
         # (-1...0).each do |i|
          #  x = end_x + i * 1
           # y = 0
          #  return false unless @chessboard[y][x] == nil
           # if @selected_piece == nil
           # @chessboard[0][rook_x] = nil
           # @chessboard[0][end_x - 1] = Piece.new(@black_rook, :black)
           #end
         # end
        #end
        
       # return true
      
      if (dx == 0 && dy == 1) || (dx == 1 && dy == 0) || (dx == dy && dy == 1) # king's move
        knight_positions = [   # check for attacking knight in destination square
          [end_y + 1, end_x + 2], [end_y + 1, end_x - 2],
          [end_y - 1, end_x + 2], [end_y - 1, end_x - 2],
          [end_y + 2, end_x - 1], [end_y + 2, end_x + 1],
          [end_y - 2, end_x - 1], [end_y - 2, end_x + 1]
        ]
        pawn_positions = []
        (-1..1).each do |offset|
          pawn_positions << [end_y + offset, end_x + offset]
        end
      
        queen_positions = []  # check for attacking queen in destination square
        (-7..7).each do |offset|
          queen_positions << [end_y + offset, end_x] 
          queen_positions << [end_y, end_x + offset] 
          queen_positions << [end_y + offset, end_x + offset] 
          queen_positions << [end_y + offset, end_x - offset] 
        end
      
        rook_positions = []  # check for attacking rook in destination square
        (-7..7).each do |offset|
          rook_positions << [end_y + offset, end_x] 
          rook_positions << [end_y, end_x + offset] 
        end
      
        bishop_positions = [] # check for attacking bishop in destination square
        (-7..7).each do |offset|
          bishop_positions << [end_y + offset, end_x + offset] 
          bishop_positions << [end_y + offset, end_x - offset] 
        end
      
        king_positions = []  # check for attacking king in destination square
        (-1..1).each do |offset|
          king_positions << [end_y + offset, end_x] 
          king_positions << [end_y, end_x + offset] 
          king_positions << [end_y + offset, end_x + offset] 
          king_positions << [end_y + offset, end_x - offset] 
        end
        
        white_king_threat = king_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @white_king }
        white_knight_threat = knight_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @white_knight }     
      
      #####################################- CHECK FOR WHITE BISHOP'S ATTACK IN DESTINATION SQUARE -######################################
        check_bishop_direction_x = 0
        check_bishop_direction_y = 0  
        bishop_threat = []  
      
        (0...8).each do |m|
          (0...8).each do |n|
            if @chessboard[n][m]&.type == @white_bishop
              bishop_dx = (m - end_x).abs
              bishop_dy = (n - end_y).abs
      
              if  bishop_dx == bishop_dy 
                check_bishop_direction_x = (m - end_x) /  bishop_dx
                check_bishop_direction_y = (n - end_y) / bishop_dy
              end
      
              bishop_threat = []
              b = 1
              loop do
                @x_bishop = end_x + (b * check_bishop_direction_x)
                @y_bishop = end_y + (b * check_bishop_direction_y)
                break if b == [bishop_dx, bishop_dy].max
                bishop_threat << [@y_bishop, @x_bishop]  
                b += 1
              end
            end
          end
        end
      
        if (bishop_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil}) || (bishop_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil || @chessboard[pos[0]][pos[1]]&.type == @black_king})
          white_bishop_threat = bishop_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @white_bishop }
        else 
          white_bishop_threat = true 
        end
      
      ############################################################- CHECK FOR WHITE QUEEN'S ATTACK IN DESTINATION SQUARE -##############################################################
        check_queen_direction_x = 0
        check_queen_direction_y = 0  
        queen_threat = []     
      
        (0...8).each do |i|
          (0...8).each do |j|
            if @chessboard[j][i]&.type == @white_queen
              queen_dx = (i - end_x).abs
              queen_dy = (j - end_y).abs
      
              if queen_dx == 0
                check_queen_direction_x = 0
                check_queen_direction_y = (j - end_y) / queen_dy
              elsif  queen_dy == 0
                check_queen_direction_x = (i - end_x) /  queen_dx
                check_queen_direction_y = 0
              elsif  queen_dx == queen_dy 
                check_queen_direction_x = (i - end_x) / queen_dx
                check_queen_direction_y = (j - end_y) / queen_dy
              end
      
              queen_threat = []
              q = 1
              loop do
                @x_queen = end_x + (q * check_queen_direction_x)
                @y_queen = end_y + (q * check_queen_direction_y)
                break if q == [queen_dx, queen_dy].max
                queen_threat << [@y_queen, @x_queen]  
                q += 1
              end
            end
          end
        end
      
        if (queen_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil}) || (queen_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil || @chessboard[pos[0]][pos[1]]&.type == @black_king})
          white_queen_threat = queen_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @white_queen }
        else 
          white_queen_threat = true 
        end
      ###################################################- CHECK FOR WHITE ROOK'S ATTACK IN DESTINATION SQUARE -###########################################################################
        check_rook_direction_x = 0
        check_rook_direction_y = 0  
        rook_threat = []     
      
        (0...8).each do |i|
          (0...8).each do |j|
            if @chessboard[j][i]&.type == @white_rook
              rook_dx = (i - end_x).abs
              rook_dy = (j - end_y).abs
      
              if rook_dx == 0
                check_rook_direction_x = 0
                check_rook_direction_y = (j - end_y) / rook_dy
              elsif  rook_dy == 0
                check_rook_direction_x = (i - end_x) /  rook_dx
                check_rook_direction_y = 0
              elsif  rook_dx == rook_dy 
                check_rook_direction_x = (i - end_x) / rook_dx
                check_rook_direction_y = (j - end_y) / rook_dy
              end
      
              rook_threat = []
              q = 1
              loop do
                @x_rook = end_x + (q * check_rook_direction_x)
                @y_rook = end_y + (q * check_rook_direction_y)
                break if q == [rook_dx, rook_dy].max
                rook_threat << [@y_rook, @x_rook]  
                q += 1
              end
            end
          end
        end
      
        if (rook_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil}) || (rook_threat.all? { |pos| @chessboard[pos[0]][pos[1]]&.type == nil || @chessboard[pos[0]][pos[1]]&.type == @black_king})
          white_rook_threat = rook_positions.none? { |pos| @chessboard[pos[0]][pos[1]]&.type == @white_rook }
        else 
          white_rook_threat = true 
        end
      
      ######################################################################################################################################################################################################
      
        return ( white_knight_threat && white_queen_threat && white_rook_threat && white_bishop_threat && white_king_threat )  
      end       

    when @white_queen, @black_queen
      if (dx == 0 && dy != 0) || (dx != 0 && dy == 0) || (dx == dy && dx > 0 && dy > 0)
        if dx == 0
          check_direction_x = 0
          check_direction_y = (end_y - start_y) / dy
        elsif dy == 0
          check_direction_x = (end_x - start_x) / dx
          check_direction_y = 0
        elsif dx == dy 
          check_direction_x = (end_x - start_x) / dx
          check_direction_y = (end_y - start_y) / dy
        end
        
        (1...[dx, dy].max).each do |i|
          x = start_x + i * check_direction_x
          y = start_y + i * check_direction_y
          
          return false unless @chessboard[y][x] == nil       
        end
      end

    else
      return true
    end
  end

end


ChessboardWindow.new.show